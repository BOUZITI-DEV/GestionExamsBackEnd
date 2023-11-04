namespace PFA.API.DTOs
{
    public class LoginResponse
    {
        public bool IsValid { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NumeroApp { get; set; }
        public List<ExamDetails> ExamDetails { get; set; } = new();
    }
}
