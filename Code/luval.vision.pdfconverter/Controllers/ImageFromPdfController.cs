using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;

using luval.vision.core;

namespace luval.vision.pdfconverter.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class ImageFromPdfController : ApiController
  {
    [HttpPost]
    public async Task<IHttpActionResult> Post()
    {
      byte[] img = null;
      /* Check if the request is multipart. */
      if (!Request.Content.IsMimeMultipartContent())
      {
        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
      }
      try
      {
        /* Get the contents of the requests. */
        var provider = new MultipartMemoryStreamProvider();
        await Request.Content.ReadAsMultipartAsync(provider);
        foreach (var file in provider.Contents)
        {
          /* Get the pdf as a byte buffer. */
          var buffer = await file.ReadAsByteArrayAsync();
          /* Convert the PDF into an Image and assign it to return value. */
          img = Pdf2Img.ConverToSingleImage(buffer);
        }
      } catch ( Exception e )
      {
        return BadRequest(e.ToString());
      }
      /* If img is null, either there were no images in the request
       * or there was an error. */
      if(img == null)
      {
        return BadRequest("There was an error converting the PDF");
      }
      return Ok(img);
    }
  }
}
