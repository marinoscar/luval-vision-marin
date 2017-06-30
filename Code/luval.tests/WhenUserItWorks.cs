using luval.vision.core;
using luval.vision.entity;
using luval.vision.bll;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.tests
{
    [TestFixture]
    public class WhenUserItWorks
    {
        [Test]
        public void ItShouldSaveUser()
        {
            OcrUser user = new OcrUser
            {
                ApiToken = "ya29.Gl1gBCq8s8T-bIYlc6By6lHiwez4Z460sflQvfLyRzVXUThrwgEUyPXhxWDWEMV-spOHy3biaTH_RR5iRj0Z5eAxvbLHsgViseeWkA7SK9LnKWrvZRXWmtFx6cB1KSU",
                Email = "harry182894@gmailcom",
                Name = "Harry",
                UserId = "harry182894gmailcom"
            };
            UserLogic userLogic = new UserLogic();
            user = userLogic.SaveOrUpdate(user.ApiToken, user.Email, user.Name, user.UserId);
            Assert.IsNotNull(user);
        }

        [Test]
        public void ItShouldGetUserList()
        {
            UserLogic userLogic = new UserLogic();
            IEnumerable<OcrUser> userList = userLogic.GetUserList();
            var user = userList.Where(u => u.UserId.Equals("harry182894gmailcom")).FirstOrDefault();
            Assert.IsNotNull(user);
        }

        [Test]
        public void ItShouldBeDeleted()
        {
            UserLogic userLogic = new UserLogic();
            Assert.IsTrue(userLogic.Delete());
        }
    }
}
