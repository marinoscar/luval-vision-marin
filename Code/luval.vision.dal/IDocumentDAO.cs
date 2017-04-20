using luval.vision.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.dal
{
    public interface IDocumentDAO
    {
        IEnumerable<OcrDocument> GetProcessResultByUserId(String userId);
        OcrDocument GetProcessResult(String id);
        IEnumerable<OcrDocument> GetProcessResults();
        bool DeleteByDocument(OcrDocument document);
        OcrDocument Save(OcrDocument document);
    }
}
