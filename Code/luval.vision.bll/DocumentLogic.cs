using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.dal;
using luval.vision.entity;

namespace luval.vision.bll
{
    public class DocumentLogic
    {
        private DocumentDAL documentDAL;

        public DocumentLogic()
        {
            documentDAL = new DocumentDAL();
        }

        public IEnumerable<OcrDocument> GetProcessResultByUserId(String userId)
        {
            return documentDAL.GetProcessResultByUserId(userId);
        }

        public OcrDocument GetProcessResultById(string id)
        {
            return documentDAL.GetProcessResult(id);
        }

        public OcrDocument Save(OcrDocument document)
        {
            return documentDAL.Save(document);
        }
    }
}
