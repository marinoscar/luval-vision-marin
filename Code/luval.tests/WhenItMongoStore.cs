using luval.vision.bll;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.dal;
using luval.vision.entity;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using luval.vision.core;

namespace luval.tests
{
    [TestFixture]
    class WhenItMongoStore
    {
        [Test]
        public void ItShouldGetDocumentRecord()
        {
            DocumentDAL documentDAL = new DocumentDAL();
            OcrDocument documentOcr = documentDAL.GetProcessResult("ee3e20db0f3c4177a6a01cf1f741db72");
            Assert.IsNotNull(documentOcr);
        }

        [Test]
        public void ItShouldDeleteDocumentRecord()
        {
            DocumentDAL documentDAL = new DocumentDAL();
            OcrDocument documentOcr = documentDAL.GetProcessResult("Sample2.jpg");
            var be = documentDAL.DeleteByDocument(documentOcr);
            Assert.IsTrue(be);
        }

        [Test]
        public void ItShouldInsertSettingsRecord()
        {
            SettingsDAL settingsDAL = new SettingsDAL();
            OcrSettings settingsOcr = new OcrSettings();
            var jsonData = File.ReadAllText("C://Users//hmuir//Documents//Pernix//luval-vision//Code//luval.tests//attribute-mapping.json");
            var options = JsonConvert.DeserializeObject<AttributeMapping[]>(jsonData);
            var be = settingsDAL.SaveOrUpdate(new OcrSettings
            {
                userId = "harry182894gmailcom",
                attributeMapping = options,
                profileName = "invoice"
            });
            Assert.IsNotNull(be);
        } 

        [Test]
        public void ItShouldLoadSettingsRecords()
        {
            SettingsDAL settingsDAL = new SettingsDAL();
            OcrSettings settingsOcr = settingsDAL.GetSettingsByUserId("harry182894gmailcom");
            Assert.IsNotNull(settingsOcr);
        }

        [Test]
        public void ItShouldDeleteSettingRecordById()
        {
            SettingsDAL settingsDAL = new SettingsDAL();
            OcrSettings settingsOcr = new OcrSettings();
            settingsOcr.userId = "harry182894gmailcom";
            var be = settingsDAL.DeleteByUserId(settingsOcr);
            Assert.IsTrue(be);
        }

        [Test]
        public void ItShouldUpdateRecord()
        {
            SettingsDAL settingsDAL = new SettingsDAL();
            OcrSettings settingsOcr = new OcrSettings();
            settingsOcr.userId = "harry182894gmailcom";
            var be = settingsDAL.SaveOrUpdate(settingsOcr);
            Assert.IsNotNull(be);
        }
    }
}
