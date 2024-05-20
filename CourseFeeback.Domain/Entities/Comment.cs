namespace CourseFeeback.Domain.Entities
{
    public record Comment
    {
        public int CommentId { get; init; }

        public required int CourseId { get; init; }

        public required int UserId { get; init; }

        public required string Content { get; init; }

        public string Sentiment { get; set; } = "Undetermined";

        public required DateOnly CreatedAt { get; init; }
    }
}
