using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA.Library.Models
{
	public class ExamSurveillant
	{
		public int? SalleId { get; set; }
		[ForeignKey(nameof(SalleId))]
		public Salle Salle { get; set; }
		public int? SurveillantId { get; set; }
		[ForeignKey(nameof(SurveillantId))]
		public Surveillant? Surveillant { get; set; }
		public int? ExamId { get; set; }
		[ForeignKey(nameof(ExamId))]
		public Exam? Exam { get; set; }
	}

}
