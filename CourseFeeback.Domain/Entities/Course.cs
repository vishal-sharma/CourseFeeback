namespace CourseFeeback.Domain.Entities
{
    public record Course
    {
        public int CourseId { get; set; }

        public required string Name { get; init; }

        public List<Comment> Comments { get; init; } = [];
    }
}
