using System.ComponentModel.DataAnnotations;

namespace FileValidation.FileExtensions
{
    public class ExtensionValidationsAttribute : ValidationAttribute
    {
        private string[] _sAllowedExt;
        public ExtensionValidationsAttribute(string[] sAllowedExt)
        {
            _sAllowedExt = sAllowedExt;
        }

        public override bool IsValid(object value)

        {
            var file = value as IFormFile;

           var  ext = Path.GetExtension(file.FileName).ToLower(); 
            if (file == null)

                return false;

            else if (!_sAllowedExt.Contains(ext))   

            {

                ErrorMessage = "Please upload Your Photo of type: " + string.Join(" , ", _sAllowedExt);

                return false;

            }
            else

                return true;

        }
    }
}
