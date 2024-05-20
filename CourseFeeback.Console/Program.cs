
using CourseFeeback.Data;
using CourseFeeback.Domain.Entities;

using (var context = new CourseFeedbackContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    context.Users.AddRange(
        [
            new User { Name = "John Doe" },
            new User { Name = "Jane Doe" },
            new User { Name = "Alice Doe" }
        ]
    );
    context.SaveChanges();

    context.Courses.AddRange(
        [
            new Course { Name = "AZ-900: Microsoft Azure Fundamentals" },
            new Course { Name = "AI-102: Designing and Implementing a Microsoft Azure AI Solution" },
            new Course { Name = "AZ-104: Microsoft Azure Administrator" },
            new Course { Name = "AZ-204: Developing Solutions for Microsoft Azure" },
            new Course { Name = "AI-900: Microsoft Azure AI Fundamentals" },
            new Course { Name = "AZ-400: Designing and Implementing Microsoft DevOps Solutions" }
        ]
    );
    context.SaveChanges();

    context.Comments.AddRange(
        [
            new Comment
            {
                CourseId = context.Courses.First(c => c.Name == "AZ-900: Microsoft Azure Fundamentals").CourseId,
                UserId = context.Users.First(u => u.Name == "John Doe").UserId,
                Content = "Great course, I learned a lot.",
                CreatedAt = DateOnly.FromDateTime(DateTime.Now)
            },
            new Comment
            {
                CourseId = context.Courses.First(c => c.Name == "AZ-900: Microsoft Azure Fundamentals").CourseId,
                UserId = context.Users.First(u => u.Name == "Jane Doe").UserId,
                Content = "I wish the course was more hands-on.",
                CreatedAt = DateOnly.FromDateTime(DateTime.Now)
            },
            new Comment
            {
                CourseId = context.Courses.First(c => c.Name == "AI-102: Designing and Implementing a Microsoft Azure AI Solution").CourseId,
                UserId = context.Users.First(u => u.Name == "Alice Doe").UserId,
                Content = "The course was very informative.",
                CreatedAt = DateOnly.FromDateTime(DateTime.Now)
            },
            new Comment
            {
                CourseId = context.Courses.First(c => c.Name == "AI-102: Designing and Implementing a Microsoft Azure AI Solution").CourseId,
                UserId = context.Users.First(u => u.Name == "John Doe").UserId,
                Content = "I wish the course was more hands-on.",
                CreatedAt = DateOnly.FromDateTime(DateTime.Now)
            },
            new Comment
            {
                CourseId = context.Courses.First(c => c.Name == "AZ-104: Microsoft Azure Administrator").CourseId,
                UserId = context.Users.First(u => u.Name == "Jane Doe").UserId,
                Content = "The course was very informative.",
                CreatedAt = DateOnly.FromDateTime(DateTime.Now)
            }
        ]
    );

    context.SaveChanges();
}
