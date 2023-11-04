namespace PFA.Library.Models
{
	public class Filiere
	{
		public int Id { get; set; }
		public string Label { get; set; }
		public List<Semestre>? Semestres { get; set; }
    }
}
