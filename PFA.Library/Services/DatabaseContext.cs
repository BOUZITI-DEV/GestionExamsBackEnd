using Microsoft.EntityFrameworkCore;
using PFA.Library.Models;

namespace PFA.Library.Services
{
	public class DatabaseContext:DbContext
	{
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Surveillant> Surveillants { get; set; }
        public DbSet<ResponsableExam> ResponsableExams { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
		public DbSet<ExamEtudiant> ExamEtudiants { get; set; }
        public DbSet<ExamSurveillant> ExamSurveillants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PFA_DB_Officielle;Trusted_Connection=True;TrustServerCertificate=True");
			base.OnConfiguring(optionsBuilder);
         
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<ExamSurveillant>().HasKey(examSurveillant => new { examSurveillant.SurveillantId, examSurveillant.ExamId });
			modelBuilder.Entity<ExamEtudiant>().HasKey(examEtudiant => new { examEtudiant.EtudiantId, examEtudiant.ExamId });

			modelBuilder.Entity<Etudiant>().Navigation(exam => exam.ExamEtudiants).AutoInclude();
            //modelBuilder.Entity<ExamEtudiant>().Navigation(exam => exam.Exam).AutoInclude();
            modelBuilder.Entity<ExamEtudiant>().Navigation(exam => exam.Salle).AutoInclude();
			
			modelBuilder.Entity<Surveillant>().Navigation(surveillant => surveillant.ExamSurveillants).AutoInclude();
			modelBuilder.Entity<ExamSurveillant>().Navigation(examSurveillant => examSurveillant.Exam).AutoInclude();
			modelBuilder.Entity<ExamSurveillant>().Navigation(examSurveillant => examSurveillant.Salle).AutoInclude();
			modelBuilder.Entity<Exam>().Navigation(exam => exam.ExamEtudiants).AutoInclude();
			modelBuilder.Entity<ExamEtudiant>().Navigation(exametudiant => exametudiant.Salle).AutoInclude();
			modelBuilder.Entity<ExamEtudiant>().Navigation(exametudiant => exametudiant.Etudiant).AutoInclude();

			base.OnModelCreating(modelBuilder);
		}
	}
}
