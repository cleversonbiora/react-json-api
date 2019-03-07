using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace React.Json.CrossCutting.Extensions
{
    public static class ExpandoObjectExtention
    {
        public static void AddNodes<T>(this ExpandoObject obj, List<T> nodes)
        {
            ExpandoObject _obj = obj;
            foreach (dynamic item in nodes)
            {
                _obj.TryAdd((string)item.Description, (object)item.Value);
            }
        }
    }
}
