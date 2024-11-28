namespace helloWorldApi.Models
{
    public class Quiz
    {
        public Guid QuizId { get; set; }
        public string Question { get; set; }
        public string Answear { get; set; }

        public Guid? CourseId { get; set; }
        public Course? CourseName { get; set; }

        public Guid? AppuserId { get; set; }
        public Appuser? Appuser { get; set; }

    }
}
