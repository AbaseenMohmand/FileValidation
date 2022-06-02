using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using FileValidation.Models;

namespace FileValidation.Controllers
{
    public class FileUploadController : Controller
    {

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv;
        public FileUploadController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }
        public IActionResult Index()
        {
            FileModel model = new FileModel();
            return View(model);

        }

        [HttpPost]
        public IActionResult Index(FileModel upload)
        {


            var file = upload.File1;


            if (ModelState.IsValid)
            {


                string FilePath = Path.Combine(hostingEnv.WebRootPath, "Files");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }


                var filePath = Path.Combine(FilePath, file.FileName);



                using (FileStream fs = System.IO.File.Create(filePath))
                {

                    file.CopyTo(fs);

                }

            }
            return View(upload);
        }
    }
}
