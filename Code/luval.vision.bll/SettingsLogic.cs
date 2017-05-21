using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.dal;
using luval.vision.entity;
using luval.vision.core;
using MongoDB.Bson;

namespace luval.vision.bll
{
    public class SettingsLogic
    {
        private SettingsDAL settingsDAL;

        public SettingsLogic()
        {
            settingsDAL = new SettingsDAL();
        }

        public OcrSettings GetSettingFileByUserId(String userId)
        {
            return settingsDAL.GetSettingFileByUserId(userId);
        }

        public IEnumerable<OcrSettings> GetSettingsByUserId(String userId)
        {
            return settingsDAL.GetSettingsByUserId(userId);
        }

        public bool DeleteByProfileName(string profileName)
        {
            return settingsDAL.DeleteByProfileName(profileName);
        }

        public OcrSettings SaveOrUpdate(string userId, AttributeMapping[] attributeMapping, string profileName)
        {
            return settingsDAL.SaveOrUpdate(new OcrSettings
            {
                Id = ObjectId.GenerateNewId().ToString(),
                userId = userId,
                attributeMapping = attributeMapping,
                profileName = profileName
            });
        }
    }
}
