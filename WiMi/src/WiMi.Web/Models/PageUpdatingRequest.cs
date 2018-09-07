using System;

namespace WiMi.Web.Models
{
    public class PageUpdatingRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
