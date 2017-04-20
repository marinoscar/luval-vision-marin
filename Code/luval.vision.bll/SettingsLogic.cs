﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.dal;
using luval.vision.entity;
using luval.vision.core;

namespace luval.vision.bll
{
    public class SettingsLogic
    {
        private SettingsDAL settingsDAL;

        public SettingsLogic()
        {
            settingsDAL = new SettingsDAL();
        }

        public OcrSettings GetSettingsByUserId(String userId)
        {
            return settingsDAL.GetSettingsByUserId(userId);
        }

        public OcrSettings SaveOrUpdate(string userId, AttributeMapping[] attributeMapping, string profileName)
        {
            return settingsDAL.SaveOrUpdate(new OcrSettings
            {
                userId = userId,
                attributeMapping = attributeMapping,
                profileName = profileName
            });
        }
    }
}
