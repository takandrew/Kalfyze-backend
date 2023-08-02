using Kalfyze_backend.Models.DTO;
using Kalfyze_backend.Models.Entities;

namespace Kalfyze_backend.Services.Interfaces
{
    public interface IService
    {
        public Task<IEnumerable<ContentTypeDTO>> GetAllContentTypes();

        public Task<ContentTypeDTO?> GetContentTypeById(int id);

        public Task<IEnumerable<Content>> GetAllContent();

        public void AddContentType(string contentTypeName);

        public Task<bool> DeleteContentType(int id);
    }
}
