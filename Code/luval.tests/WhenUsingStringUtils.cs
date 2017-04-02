using luval.vision.core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.tests
{
    [TestFixture]
    public class WhenUsingStringUtils
    {
        [Test]
        public void DistanceOptionShouldWork()
        {
            var res1 = StringUtils.CalculateLevenshteinDistance("total", "tota");
            var res2 = StringUtils.CalculateLevenshteinDistance("Facebook", "Facebok");
            var res3 = StringUtils.CalculateLevenshteinDistance("Invoice", "Marin Saenz");
        }

    }
}
