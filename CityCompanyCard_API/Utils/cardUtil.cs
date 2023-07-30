using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Utils
{
    public class cardUtil
    {
        public static object? DeepCopyObject(object obj)
        {
            Type type = obj.GetType();

            if (type.IsArray)
            {
                Type elementType = type.GetElementType()!;
                Array array = (Array)obj;
                Array copy = Array.CreateInstance(elementType, array.Length);

                for (int i = 0; i < array.Length; i++)
                {
                    object? element = array.GetValue(i);
                    object? elementCopy = element != null ? DeepCopyObject(element) : null;
                    copy.SetValue(elementCopy, i);
                }

                return copy;
            }
            else if (type.IsClass && !type.IsSealed && !type.IsAbstract)
            {
                MethodInfo method = type.GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
                object copy = method != null ? method.Invoke(obj, null) : null;

                return copy;
            }
            else
            {
                return obj;
            }
        }
    }
}
