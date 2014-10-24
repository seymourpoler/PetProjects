using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;

namespace TodoList.Console
{
    public class WebComponent
    {
        private Func<IDictionary<string, object>, Task> _next;
        Hashtable _values;
        public WebComponent(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
            _values = new Hashtable();
            _values.Add("owin.Version", 13);
            _values.Add("owin.RequestQueryString", 7);    
            _values.Add("owin.RequestStatusCode", 6);    
            _values.Add("owin.RequestId", 5);    
            _values.Add("owin.RequestProtocol", 12);    
            _values.Add("owin.RequestBody", 4);    
            _values.Add("owin.RequestHeaders", 2);    
            _values.Add("owin.ResponseBody", 3);    
            _values.Add("owin.ResponseHeaders", 1);    
            _values.Add("owin.RequestPath", 0);    
            _values.Add("owin.RequestSchema", 10);    
            _values.Add("host.AppName", 15);    
            _values.Add("server.LocalPort",24);    
            _values.Add("server.RemotePort", 22);    
            _values.Add("server.LocalIpAdrees", 23);    
            _values.Add("server.RemoteIpAddress", 21);    

        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var request = string.Empty;
            foreach (var element in environment)
            {
                request += "Key: " + element.Key + "; Value: " + element.Value + "\n";
            }

            System.Console.Write(request);

            //foreach (var field in _values.Keys)
            //{
            //    System.Console.WriteLine(string.Format("key: {0}, value: {1}", "owin.Version", (string)((object[])(environment.Values))[(int)_values[field]]));
            //}
           

            await _next.Invoke(environment);
        }
    }
}
