using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace SR.Global.Pages
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment _host;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _host = hostingEnvironment;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            Debug.WriteLine(Request.Form["first_name"]);
            Debug.WriteLine(Request.Form["last_name"]);
            Debug.WriteLine(Request.Form["email"]);

            

            var path = Path.Combine(_host.WebRootPath, "content\\flyer.pdf");
            var content = await System.IO.File.ReadAllBytesAsync(path);

            var fileName = Path.GetRandomFileName() + ".pdf";
            return File(content, "application/pdf", fileName);


        }
    }
}