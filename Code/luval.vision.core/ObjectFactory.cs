using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace luval.vision.core
{
    public static class ObjectFactory
    {
        public static object Create(string typeName)
        {
            if (string.IsNullOrWhiteSpace(typeName)) throw new ArgumentNullException("typeName");
            Type type = null;
            Assembly assembly;
            var fullName = GetFullName(typeName);
            object result;
            try
            {
                if (string.IsNullOrWhiteSpace(fullName.Item2))
                {
                    type = Type.GetType(fullName.Item1);
                    result = Activator.CreateInstance(type);
                }
                else
                {
                    assembly = Assembly.Load(fullName.Item2);
                    type = assembly.GetType(fullName.Item1);
                    result = Activator.CreateInstance(type);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to create instance", "typeName", ex);
            }
            return result;
        }

        private static Tuple<string, string> GetFullName(string typeName)
        {
            var parts = typeName.Split(',');
            if (parts.Length == 1) return new Tuple<string, string>(typeName, null);
            return new Tuple<string, string>(parts[0], string.Join(",", parts.Skip(1)));
        }

        public static T Create<T>(string typeName)
        {
            return (T)Create(typeName);
        }
    }
}
