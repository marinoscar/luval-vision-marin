using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using MongoDB.Bson;

namespace luval.vision.dal
{
    public interface IDocumentDAO
    {
        OcrDocument SaveOrUpdate(OcrDocument processResult);
        IEnumerable<OcrDocument> GetProcessResults();
        OcrDocument GetProcessResult(String id);
        IEnumerable<OcrDocument> GetProcessResultByUserId(String userId);

    }
}
