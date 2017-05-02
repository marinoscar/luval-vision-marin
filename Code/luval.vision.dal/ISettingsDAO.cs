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
        IEnumerable<OcrSettings> GetSettingsByUserId(String userId);
        OcrSettings GetSettingFileByUserId(String userId);
        OcrSettings GetSettingsById(String id);
        OcrSettings GetSettingsByProfileName(String userId);
        IEnumerable<OcrSettings> GetSettings();
        bool DeleteByUserId(OcrSettings settings);
        OcrSettings SaveOrUpdate(OcrSettings settings);
    }
}
