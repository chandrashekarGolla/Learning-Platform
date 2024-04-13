using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;



namespace Learning_Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterRepository _repository;

        public ChapterController(IChapterRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<Chapter>> GetAllChapters()
        {
            return await _repository.GetAllChapters();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapterById(string id)
        {
            var chapter = await _repository.GetChapterById(id);
            if (chapter == null)
            {
                return NotFound();
            }
            return chapter;
        }

        [HttpPost]
        public async Task<ActionResult<Chapter>> CreateChapter(Chapter chapter)
        {
            await _repository.CreateChapter(chapter);
            return CreatedAtAction(nameof(GetChapterById), new { id = chapter.Id }, chapter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChapter(string id, Chapter chapter)
        {
            if (id != chapter.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateChapter(chapter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(string id)
        {
            var chapterToDelete = await _repository.GetChapterById(id);
            if (chapterToDelete == null)
            {
                return NotFound();
            }
            await _repository.DeleteChapter(id);
            return NoContent();
        }
    }
}
