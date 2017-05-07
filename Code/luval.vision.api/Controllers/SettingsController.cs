using luval.vision.core;
using luval.vision.entity;
using luval.vision.bll;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SettingsController : ApiController
    {
        private SettingsLogic settingsLogic;

        public SettingsController()
        {
            settingsLogic = new SettingsLogic();
        }

        [Route("api/v1/Settings/GetProfiles")]
        [HttpGet]
        public IHttpActionResult GetProfiles(string userId)
        {
            try
            {
                var settingsList = settingsLogic.GetSettingsByUserId(userId);
                if(settingsList.Count() > 0)
                {
                    return Ok(settingsList);
                }
                return Ok(new OcrSettings
                {
                    profileName = "invoice"
                });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        public IHttpActionResult Get(string userId)
        {
            try
            {
                OcrSettings settings = settingsLogic.GetSettingFileByUserId(userId);
                if (settings != null)
                {
                    return Ok(settings.attributeMapping);
                }
                else
                {
                    var jsonData = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/attribute-mapping.json"));
                    var options = JsonConvert.DeserializeObject<AttributeMapping[]>(jsonData);
                    return Ok(options);
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            AttributeMapping[] attributeMapping = null;
            var provider = GetMultipartProvider();
            try
            {
                var result = await Request.Content.ReadAsMultipartAsync(provider);
                var originalFileName = GetDeserializedFileName(result.FileData.First());
                var userId = result.FormData.GetValues(1).FirstOrDefault();
                var profileName = result.FormData.GetValues(0).FirstOrDefault();
                foreach (MultipartFileData file in result.FileData)
                {
                    var jsonData = File.ReadAllText(file.LocalFileName);
                    attributeMapping = JsonConvert.DeserializeObject<AttributeMapping[]>(jsonData);
                    var bytes = Pdf2Img.CheckForPdfAndConvert(File.ReadAllBytes(file.LocalFileName), file.LocalFileName, file.Headers.ContentDisposition.FileName);
                    settingsLogic.SaveOrUpdate(userId, attributeMapping, profileName);
                }
                return Ok(attributeMapping);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            var root = HttpContext.Current.Server.MapPath("~/App_Data/documents");
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        private string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}
