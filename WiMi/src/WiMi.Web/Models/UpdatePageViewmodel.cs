using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WiMi.Web.Models
{
    public class UpdatePageViewModel : PageModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
