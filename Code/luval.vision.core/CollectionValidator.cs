using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class CollectionValidator
    {
        public static bool IEnumerableCollectionIsNotNull(IEnumerable collection)
        {
            return !collection.Equals(null);
        }
    }
}
