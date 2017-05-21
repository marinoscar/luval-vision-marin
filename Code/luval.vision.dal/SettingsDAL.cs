using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;

namespace luval.vision.dal
{
    public class SettingsDAL : ISettingsDAO
    {
        public OcrSettings GetSettingFileByUserId(String userId)
        {
            var settings = Query<OcrSettings>.EQ(u => u.userId, userId);
            return MongoConn.mongoDB()
                .GetCollection<OcrSettings>("settings")
                .FindOne(settings);
        }

        public OcrSettings GetSettingsByProfileName(String profileName)
        {
            var settings = Query<OcrSettings>.EQ(p => p.profileName, profileName);
            return MongoConn.mongoDB()
                .GetCollection<OcrSettings>("settings")
                .FindOne(settings);
        }

        public OcrSettings GetSettingsById(String id)
        {
            var settings = Query<OcrSettings>.EQ(u => u.Id, id);
            return MongoConn.mongoDB()
                .GetCollection<OcrSettings>("settings")
                .FindOne(settings);
        }

        public IEnumerable<OcrSettings> GetSettingsByUserId(String userId)
        {
            var settingList = MongoConn.mongoDB()
                .GetCollection<OcrSettings>("settings")
                .FindAll();
            
            return settingList.Where(s => s.userId == userId).ToList();
        }

        public IEnumerable<OcrSettings> GetSettings()
        {
            return MongoConn.mongoDB()
                .GetCollection<OcrSettings>("settings")
                .FindAll();
        }

        public bool DeleteByUserId(OcrSettings settings)
        {
            try
            {
                var settingsList = MongoConn.mongoDB().GetCollection("settings");
                IMongoQuery query = Query.EQ("user_id", settings.userId);
                settingsList.Remove(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteByProfileName(string profileName)
        {
            try
            {
                var settingsList = MongoConn.mongoDB().GetCollection("settings");
                IMongoQuery query = Query.EQ("profile_name", profileName);
                settingsList.Remove(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OcrSettings SaveOrUpdate(OcrSettings settings)
        {
            var settingsList = MongoConn.mongoDB().GetCollection("settings");
            WriteConcernResult result;
            var existingItem = GetSettingsByProfileName(settings.profileName);

            if (existingItem == null)
            {
                result = settingsList.Insert<OcrSettings>(settings);
            }
            else
            {
                settings.Id = existingItem.Id;
                result = settingsList.Save<OcrSettings>(settings);
            }
            return settings;
        }
    }
}
