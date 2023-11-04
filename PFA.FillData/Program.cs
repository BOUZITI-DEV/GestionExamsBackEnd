using PFA.Library.Models;
using PFA.Library.Services;


DatabaseContext context = new DatabaseContext();
//creation des salles
context.Salles.AddRange(new List<Salle>()
{
	new Salle()
	{
		Label="A1"
	},
	new Salle()
	{
		Label="B2"
	},
	new Salle()
	{
		Label="C3"
	}
});
context.SaveChanges();
Console.WriteLine("Salles created");
context.Matieres.AddRange(new List<Matiere>()
{
	new Matiere()
	{
		Label="Oracle"
	},
	new Matiere()
	{
		Label=".Net"
	}, new Matiere()
	{
		Label="Django"
	}
});
context.SaveChanges();
Console.WriteLine("Matieres created");
context.Exams.AddRange(new List<Exam>()
{
	new Exam()
	{
		Label="Examen Oracle",
		DateDebut=DateTime.Now,
		DateFin=DateTime.Now.AddHours(2),
		MatiereId=context.Matieres.First(m=>m.Label=="Oracle").Id,
	},
	new Exam()
	{
		Label="Examen .Net",
		DateDebut=DateTime.Now.AddDays(1).AddHours(-2),
		DateFin=DateTime.Now.AddDays(1),
		MatiereId=context.Matieres.First(m=>m.Label==".Net").Id,
	},
	new Exam()
	{
		Label="Examen Django",
		DateDebut=DateTime.Now.AddDays(3).AddHours(4),
		DateFin=DateTime.Now.AddDays(3).AddHours(6),
		MatiereId=context.Matieres.First(m=>m.Label=="Django").Id,
	}
});
context.SaveChanges();
Console.WriteLine("Exams created");

context.Etudiants.AddRange(new List<Etudiant>()
{
	new Etudiant()
	{
		CNE="EE523523",
		Login="Boutissante",
		Nom = "Boutissnte",
		Prenom = "Issam",
		N_Apo="B123",
		Password="123"
	},
	new Etudiant()
	{
		CNE="EE42353",
		Login="salama",
		Nom="Daali",
		Prenom="Salama",
		N_Apo="S123",
		Password="123"
	},
	new Etudiant()
	{
		CNE="EE52335",
		Login="oussama",
		Nom="Boutissante",
		Prenom="Oussama",
		N_Apo="O123",
		Password="123"
	},
	new Etudiant()
	{
		CNE="EE5234",
		Login="farah",
		Nom="Boutissante",
		Prenom="Farah",
		N_Apo="F123",
		Password="123"
	}
});
context.SaveChanges();
Console.WriteLine("Etudiants created");
//affecter exam a etudiants
context.ExamEtudiants.AddRange(new List<ExamEtudiant>()
{
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Issam").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Oracle").Id,
		SalleId=context.Salles.First(s=>s.Label=="A1").Id,
		Table="A1 1"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Salama").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Oracle").Id,
		SalleId=context.Salles.First(s=>s.Label=="A1").Id,
		Table="A1 2"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Oussama").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Oracle").Id,
		SalleId=context.Salles.First(s=>s.Label=="A1").Id,
		Table="A1 3"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Farah").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Oracle").Id,
		SalleId=context.Salles.First(s=>s.Label=="A1").Id,
		Table="A1 4"
	},


	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Issam").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen .Net").Id,
		SalleId=context.Salles.First(s=>s.Label=="B2").Id,
		Table="B2 1"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Salama").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen .Net").Id,
		SalleId=context.Salles.First(s=>s.Label=="B2").Id,
		Table="B2 2"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Oussama").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen .Net").Id,
		SalleId=context.Salles.First(s=>s.Label=="B2").Id,
		Table="B2 3"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Farah").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen .Net").Id,
		SalleId=context.Salles.First(s=>s.Label=="B2").Id,
		Table="B2 4"
	},


	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Issam").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Django").Id,
		SalleId=context.Salles.First(s=>s.Label=="C3").Id,
		Table="C3 1"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Salama").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Django").Id,
		SalleId=context.Salles.First(s=>s.Label=="C3").Id,
		Table="C3 2"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Oussama").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Django").Id,
		SalleId=context.Salles.First(s=>s.Label=="C3").Id,
		Table="C3 3"
	},
	new ExamEtudiant()
	{
		EtudiantId=context.Etudiants.First(e=>e.Prenom=="Farah").Id,
		ExamId=context.Exams.First(e=>e.Label=="Examen Django").Id,
		SalleId=context.Salles.First(s=>s.Label=="C3").Id,
		Table="C3 4"
	}
});
context.SaveChanges();
Console.WriteLine("ExamEtudiants created");
//creationg de surveillant
context.Surveillants.Add(new Surveillant()
{
	Login = "omar",
	Nom = "Boutissante",
	Password = "123",
	Prenom = "Omar"
});
context.SaveChanges();
Console.WriteLine("Surveillant created");
//affecter exam a surveillant
context.ExamSurveillants.AddRange(new List<ExamSurveillant>(){
	new ExamSurveillant()
	{
		SurveillantId = context.Surveillants.First(s => s.Prenom == "Omar").Id,
		ExamId = context.Exams.First(e => e.Label == "Examen Oracle").Id,
		SalleId = context.Salles.First(s => s.Label == "A1").Id
	},
	new ExamSurveillant()
	{
		SurveillantId = context.Surveillants.First(s => s.Prenom == "Omar").Id,
		ExamId = context.Exams.First(e => e.Label == "Examen .Net").Id,
		SalleId = context.Salles.First(s => s.Label == "B2").Id
	},
	new ExamSurveillant()
	{
		SurveillantId = context.Surveillants.First(s => s.Prenom == "Omar").Id,
		ExamId = context.Exams.First(e => e.Label == "Examen Django").Id,
		SalleId = context.Salles.First(s => s.Label == "C3").Id
	}
});
context.SaveChangesAsync();
Console.WriteLine("ExamSurveillant created");
