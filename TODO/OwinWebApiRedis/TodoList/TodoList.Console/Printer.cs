using System;
using System.Collections;
using System.Reflection;

namespace TodoList.Console
{
    public class Printer
    {
        public static void Print(object objectToPrint)
        {
            //PropertyInfo[] propertyInfos;
            //propertyInfos = objectToPrint.GetType().GetProperties(BindingFlags.Public |
            //                                              BindingFlags.Static);
            //Array.Sort(propertyInfos,
            //        delegate(PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
            //        { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            //foreach (PropertyInfo propertyInfo in propertyInfos)
            //{
            //    System.Console.WriteLine(string.Format("name:{0} value: {1}", propertyInfo.Name, propertyInfo.GetValue(objectToPrint, null)));
            //}

            //foreach (PropertyInfo info in objectToPrint.GetType().GetProperties())
            //{
            //    if (info.CanRead)
            //    {
            //        object o = propertyInfo.GetValue(myObject, null);
            //    }
            //}
            PrintProperties(objectToPrint, 0);
        }

        private static void PrintProperties(object obj, int indent)
        {
            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                var elems = propValue as IList;
                if (elems != null)
                {
                    foreach (var item in elems)
                    {
                        PrintProperties(item, indent + 3);
                    }
                }
                else
                {
                    // This will not cut-off System.Collections because of the first check
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        System.Console.WriteLine("{0}{1}:", indentString, property.Name);

                        PrintProperties(propValue, indent + 2);
                    }
                    else
                    {
                        System.Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                    }
                }
            }
        }
    }
}
