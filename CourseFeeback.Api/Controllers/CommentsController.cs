using CourseFeeback.Data;
using CourseFeeback.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectReview.ExternalServices;

namespace CourseFeeback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CourseFeedbackContext _context;
        private readonly ISentimentAnalysisService _sentimentAnalysisService;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(CourseFeedbackContext context, ISentimentAnalysisService sentimentAnalysisService, ILogger<CommentsController> logger)
        {
            _context = context;
            _sentimentAnalysisService = sentimentAnalysisService;
            _logger = logger;
        }
         
        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            var sentiment = _sentimentAnalysisService.GetSentiment(comment.Content);
            comment.Sentiment = sentiment;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Comment for course {comment.CourseId} was created with sentiment {sentiment}");
            return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
