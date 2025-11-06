namespace QMS.Models
{
    public class CertificationQuestion
    {
        public int CertificationId { get; set; }
        public string CertificationName { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<Option> Options { get; set; }
        public int CorrectOptionId { get; set; }
        public string CorrectOptionText { get; set; }
    }

    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
    }
}
