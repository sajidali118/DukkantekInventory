using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Dukkantek.Domain.Utilities
{
    public static class EnumExtensionsMethod
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

        public static string GetDisplay(this Enum enumValue)
        {
            var displayName = enumValue.GetType()?
                     .GetMember(enumValue.ToString())?.First()?
                     .GetCustomAttribute<DisplayAttribute>()?
                     .Name;
            return displayName;
        }

        public static object ToType<T>(this object obj, T type)
        {

            //create instance of T type object:
            var tmp = Activator.CreateInstance(Type.GetType(type.ToString()));

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {

                    //get the value of property and try 
                    //to assign it to the property of T type object:
                    tmp.GetType().GetProperty(pi.Name).SetValue(tmp,
                                              pi.GetValue(obj, null), null);
                }
                catch { }
            }

            //return the T type object:         
            return tmp;
        }

        public static object ToNonAnonymousList<T>(this List<T> list, Type t)
        {

            //define system Type representing List of objects of T type:
            var genericType = typeof(List<>).MakeGenericType(t);

            //create an object instance of defined type:
            var l = Activator.CreateInstance(genericType);

            //get method Add from from the list:
            MethodInfo addMethod = l.GetType().GetMethod("Add");

            //loop through the calling list:
            foreach (T item in list)
            {

                //convert each object of the list into T object 
                //by calling extension ToType<T>()
                //Add this object to newly created list:
                addMethod.Invoke(l, new object[] { item.ToType(t) });
            }

            //return List of T objects:
            return l;
        }

        public static List<T> MakeList<T>(T itemOftype)
        {
            List<T> newList = new List<T>();
            return newList;
        }

        public static List<T> MakeList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
}
