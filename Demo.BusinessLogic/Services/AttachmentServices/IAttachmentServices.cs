using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.AttachmentServices.AttachmentServices
{
    public interface IAttachmentServices
    {
        // Upload File (File And Folder Name that will Upload )
        string? Upload(IFormFile file,string FolderName );

        // Delete 
        bool Delete(string filePath);

    }
}
