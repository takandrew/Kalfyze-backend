using Kalfyze_backend.Data.Interfaces;
using Kalfyze_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kalfyze_backend.Data
{
    public class ValuesRepository : IRepository
    {
        private KalfyzeDbContext _context;

        public ValuesRepository(KalfyzeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Content_Type>> GetAllContentTypes()
        {
            return await _context.ContentTypes.ToListAsync();
        }

        public async Task<Content_Type?> GetContentTypeById(int id)
        {
            return await _context.ContentTypes.FindAsync(id);
        }

        public async Task<IEnumerable<Content>> GetAllContent()
        {
            return await _context.Contents.Include(x => x.Type).Include(x => x.Franchise).ToListAsync();
        }

        public void AddContentType(Content_Type contentType)
        {
            _context.ContentTypes.Add(contentType);
            _context.SaveChanges();
        }

        public async Task<bool> DeleteContentType(int id)
        {
            var contenttype = await _context.ContentTypes.FindAsync(id);
            if (contenttype != null)
            {
                _context.ContentTypes.Remove(contenttype);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
