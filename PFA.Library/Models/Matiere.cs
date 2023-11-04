namespace PFA.Library.Models
{
	public class Matiere
	{
        public int Id { get; set; }
        public string Label { get; set; }
        public Semestre? Semestre { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
