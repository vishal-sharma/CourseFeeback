namespace CourseFeeback.Domain.Entities
{
    public record User
    {
        public int UserId { get; init; }

        public required string Name { get; init; }

        public List<Comment> Comments { get; init; } = [];
    }
}
