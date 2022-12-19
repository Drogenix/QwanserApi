
using System.ComponentModel.DataAnnotations;

namespace QwanserApi.Entity
{
    public class User : Entity
    {
        [MaxLength(24, ErrorMessage = "Username max length must be 24 symbols.")]
        public string Username { get; set; }
        [MaxLength(32, ErrorMessage = "Password max length must be 32 symbols.")]
        public string Password{ get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastActivity { get; set; }
        [MaxLength(300, ErrorMessage = "Bio length cannot be longer then 300 symbols.")]
        public string Bio { get; set; }
        public virtual List<Socials> Socials { get; set; }
        public string ImageUrl { get; set; }
        public int AnswersCount { get; set; }
        public int QuestionsCount { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<Question> Questions{ get; set; }
    }
}
