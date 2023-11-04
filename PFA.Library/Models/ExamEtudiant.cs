using System.ComponentModel.DataAnnotations.Schema;

namespace PFA.Library.Models
{
	public class ExamEtudiant
	{
        public string Table { get; set; }
        public int? SalleId { get; set; }
        [ForeignKey(nameof(SalleId))]
        public Salle? Salle { get; set; }
        public int? EtudiantId { get; set; }
        [ForeignKey(nameof(EtudiantId))]
        public Etudiant? Etudiant { get; set; }
		public int? ExamId { get; set; }
		[ForeignKey(nameof(ExamId))]
		public Exam? Exam { get; set; }
        public bool IsPresent { get; set; }
    }
}
