using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.Services.AttachmentServices.AttachmentServices;
using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.AttachmentServices
{
    public class AttachmentService : IAttachmentServices
    {
        List<string> _attachments = [".jpg", ".png", ".Jpeg"];
        const int maxFileSize = 2_097_152;
        public string? Upload(IFormFile file, string FolderName)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_attachments.Contains(extension)) return null;

            if (file.Length == 0 || file.Length > maxFileSize) return null;

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files",FolderName);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(folderPath, fileName);


              using  FileStream fs = new FileStream(filePath, FileMode.Create);
            //try
            //{
            //}
            //finally
            //{
            //    fs.Dispose();

            //}

            file.CopyTo(fs);
            //File.Create(filePath);

            return fileName;


        }
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath)) return false;
            try
            {
                File.Delete(filePath);
            }
            catch
            {



            }
            return true;
        }

    }
}
