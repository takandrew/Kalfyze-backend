using Kalfyze_backend.Data;
using Kalfyze_backend.Models.DTO;
using Kalfyze_backend.Models.Entities;

namespace Kalfyze_backend.Services
{
    public class ValuesService
    {
        private ValuesRepository _valuesRepository;

        public ValuesService(ValuesRepository valuesRepository)
        {
             _valuesRepository = valuesRepository;
        }

        public async Task<IEnumerable<ContentTypeDTO>> GetAllContentTypes()
        {
            var contentTypes = await _valuesRepository.GetAllContentTypes();
            var contentTypesDTO = new List<ContentTypeDTO>();
            foreach (var contentType in contentTypes)
            {
                contentTypesDTO.Add(new ContentTypeDTO
                {
                    Id = contentType.Id,
                    Name = contentType.Name,
                });
            }
            return contentTypesDTO;
        }

        public async Task<ContentTypeDTO?> GetContentTypeById(int id)
        {
            var contentType = await _valuesRepository.GetContentTypeById(id);
            if (contentType != null)
            {
                return new ContentTypeDTO { Id = contentType.Id, Name = contentType.Name };
            }
            else
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<Content>> GetAllContent()
        {
            return await _valuesRepository.GetAllContent();
        }

        public void AddContentType(string contentTypeName)
        {
            var contentType = new Content_Type();
            contentType.Name = contentTypeName;
            _valuesRepository.AddContentType(contentType);
        }

        public async Task<bool> DeleteContentType(int id)
        {
            return await _valuesRepository.DeleteContentType(id);
        }

    }
}
