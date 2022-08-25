using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Details> Details;

        public void OnGet()
        {
            GetService service = new GetService();
            Details = service.GetDetails();     

        }
    }
}
