using luval.vision.bll;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.dal;
using luval.vision.entity;

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
            var be = documentDAL.Delete(documentOcr);
            Assert.IsTrue(be);
        }
    }
}
