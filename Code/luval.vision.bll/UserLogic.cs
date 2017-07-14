using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿using luval.vision.dal;
using luval.vision.entity;

namespace luval.vision.bll
{
    public class UserLogic
    {
        private UserDAL userDAL;

        public UserLogic()
        {
            userDAL = new UserDAL();
        }

        public OcrUser GetUser(string email)
        {
            return userDAL.GetUser(email);
        }

        public bool isAuthenticationValid(string email, string tokenId)
        {
            return userDAL.isAuthenticationValid(email, tokenId);
        }

        public bool isApproved(string email)
        {
            return userDAL.isApproved(email);
        }

        public IEnumerable<OcrUser> GetUserList()
        {
            return userDAL.GetUserList();
        }

        public bool Delete()
        {
            return userDAL.Delete();
        }

        public OcrUser SaveOrUpdate(string tokenId, string email, string name, string userId)
        {
            return userDAL.SaveOrUpdate(new OcrUser
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Email = email,
                ApiToken = tokenId,
                Name = name,
                UserId = userId
            });
        }

        public OcrUser SaveOrUpdate(OcrUser user)
        {
            return userDAL.SaveOrUpdate(user);
        }
    }
}
