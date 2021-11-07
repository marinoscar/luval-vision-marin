using System;
using System.Collections.Generic;
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
            var nameParts = typeName.Split(',');
            object result;
            try
            {
                if (nameParts.Length == 1)
                {
                    type = Type.GetType(nameParts[0]);
                    result = Activator.CreateInstance(type);
                }
                else
                {
                    assembly = Assembly.Load(nameParts[0]);
                    type = assembly.GetType(nameParts[1]);
                    result = Activator.CreateInstance(type);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to create instance", "typeName", ex);
            }
            return result;
        }

        public static T Create<T>(string typeName)
        {
            return (T)Convert.ChangeType(Create(typeName), typeof(T));
        }
    }
}
