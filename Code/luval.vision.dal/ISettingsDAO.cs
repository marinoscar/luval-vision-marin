using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;

namespace luval.vision.dal
{
    public interface ISettingsDAO
    {
        OcrSettings GetSettingsByUserId(String userId);
        OcrSettings GetSettingsById(String id);
        IEnumerable<OcrSettings> GetSettings();
        bool DeleteByUserId(OcrSettings settings);
        OcrSettings SaveOrUpdate(OcrSettings settings);
    }
}
