using FileValidation.FileExtensions;
using System.ComponentModel.DataAnnotations;

namespace FileValidation.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "Please select file")]
        [ExtensionValidations(new string[] {".jpg",".docx",".png"})]
        public IFormFile File1 { get; set; }

    }


 
   
}
