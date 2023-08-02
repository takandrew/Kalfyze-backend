using Kalfyze_backend.Models.Entities;

namespace Kalfyze_backend.Data.Interfaces
{
    public interface IRepository
    {
        public Task<IEnumerable<Content_Type>> GetAllContentTypes();

        public Task<Content_Type?> GetContentTypeById(int id);

        public Task<IEnumerable<Content>> GetAllContent();

        public void AddContentType(Content_Type contentType);

        public Task<bool> DeleteContentType(int id);
    }
}
