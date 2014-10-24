using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoList.Console
{
    public class WebComponent
    {
        private Func<IDictionary<string, object>, Task> _next;
        public WebComponent(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var response = string.Empty;
            foreach (var element in environment)
            {
                response += "Key: " + element.Key + "; Value: " + element.Value + "\n";
            }

            System.Console.Write(response);
            await _next.Invoke(environment);
        }

    }
}
