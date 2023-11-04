using System.ComponentModel.DataAnnotations.Schema;

namespace PFA.Library.Models
{
	public class Exam
	{
        public int Id { get; set; }
        public string Label { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public List<ExamEtudiant>? ExamEtudiants { get; set; }
        public List<ExamSurveillant>? ExamSurveillants { get; set; }
        public int? MatiereId { get; set; }
        [ForeignKey(nameof(MatiereId))]
        public Matiere? Matiere { get; set; }
    }
}
