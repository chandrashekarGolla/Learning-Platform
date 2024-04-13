using System.Collections.Generic;
using System.Threading.Tasks;
using Models;



namespace Repositories
{
    public interface IChapterRepository
    {
        Task<IEnumerable<Chapter>> GetAllChapters();
        Task<Chapter> GetChapterById(string id);
        Task CreateChapter(Chapter chapter);
        Task UpdateChapter(Chapter chapter);
        Task DeleteChapter(string id);
    }
}

