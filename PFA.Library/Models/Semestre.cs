namespace PFA.Library.Models
{
	public class Semestre
	{
        public int Id { get; set; }
        public string Label { get; set; }
        public Filiere? Filiere { get; set; }
        public List<Matiere>? Matieres { get; set; }
    }
}
