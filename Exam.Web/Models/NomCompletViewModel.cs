namespace Exam.Web.Models
{
    public class NomCompletViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName}, {LastName}";
        }
    }
}