using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.dal;
using luval.vision.entity;

namespace luval.tests
{
    [TestFixture]
    class WhenMongoDBIsStoring
    {
        [Test]
        public void ItShouldStoreUser()
        {
            UserDAL userDAL = new UserDAL();
            OcrUser user = new OcrUser
            {
                tokenId = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImE0ZDk4YWRiN2I0ZjcxNzZmMmUwODEyYzBiYWFjMDgyYmMxMzU5N2YifQ.eyJhenAiOiIzODc1MzM3Mjg2NjItb3ZxbHB1MjdyYWl0Mm01aWRzYTZhYWRxZjdxYTAwZTQuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiIzODc1MzM3Mjg2NjItb3ZxbHB1MjdyYWl0Mm01aWRzYTZhYWRxZjdxYTAwZTQuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDQ5MDIxMTAyNTYyNDgwNTI1MTUiLCJlbWFpbCI6ImhhcnJ5MTgyODk0QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJhdF9oYXNoIjoiZ0lzMEEwYVg0cGZTWG5mbS1VcV9EdyIsImlzcyI6ImFjY291bnRzLmdvb2dsZS5jb20iLCJpYXQiOjE0OTExNzc1NzMsImV4cCI6MTQ5MTE4MTE3MywibmFtZSI6IkhhcnJ5IE11aXIiLCJwaWN0dXJlIjoiaHR0cHM6Ly9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tLy1Mc3F1N2ZTSFd0cy9BQUFBQUFBQUFBSS9BQUFBQUFBQUFBQS9BTWNBWWktb0wzaE00UFd4d2RNQ0REZy1pWTlzSU1wdmNnL3M5Ni1jL3Bob3RvLmpwZyIsImdpdmVuX25hbWUiOiJIYXJyeSIsImZhbWlseV9uYW1lIjoiTXVpciIsImxvY2FsZSI6ImVzIn0.Ng7VfMDkkRKPTLLeFpiZu5EbfIVqXC5fIS_WQw6IhmL_kjC5G-oFDyo-6UGggdVZCAYgbXowFuVB-Jj1pxaFum48CGF35IBnVK9PBuswhlesjxAjZYYHBzXq4KmzY11QUQ-xSeyO0z_apkwQcimQ5y2nlInq16xEhIqi2AQNQaC0pbhQBa-NzN0vAFJE4v0ID9iRJ9vEF9KFilFTNR8XLqrZp9m-Qa1Ndp0qiYYsGAZc59AKuDd16rx9bdyDJb1GpsEJtpjeX4xN6JCJ0vIfgkB20xbNLpzG0P3YCTMsKQyfgp89f1Cy4pabHslGT8aTOND0kpgYb4Uau_KozW58Ow"
            };
            userDAL.SaveOrUpdate(user);
        }

        [Test]
        public void ItShouldGetUsers()
        {
            UserDAL userDAL = new UserDAL();
            IEnumerable<OcrUser> users = userDAL.GetUsers();
            OcrUser user = users.FirstOrDefault();
            Assert.IsTrue(users.Count() > 0);
        }

        [Test]
        public void ItShouldGetUserById()
        {
            UserDAL userDAL = new UserDAL();
            OcrUser user = userDAL.GetUser("58e192c34a8d102318ec4043");
            Assert.IsNotNull(user);
        }
    }
}
