namespace PFA.Library.Models
{
	public class Etudiant:Utilisateur
	{
        public string N_Apo { get; set; }
        public string CNE { get; set; }
        public List<ExamEtudiant>? ExamEtudiants { get; set; }
    }
}
