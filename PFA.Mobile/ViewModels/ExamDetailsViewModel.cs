using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PFA.Mobile.Services;
using PFA.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA.Mobile.ViewModels
{
	public partial class ExamDetailsViewModel:BaseViewModel
	{
        public Exam Exam { get; set; }
        [ObservableProperty]
        private ObservableCollection<ExamEtudiant> examEtudiants=new();
        public ExamDetailsViewModel(Exam exam)
        {
            this.Exam = exam;
        }
        public async Task VerifyEtudiant(string numeroApp)
        {
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

			var snackbarOptions = new SnackbarOptions
			{
				BackgroundColor = Colors.White,
				TextColor = Colors.Green,
				
				ActionButtonTextColor = Colors.Gray,
				CornerRadius = new CornerRadius(10),
				Font = Microsoft.Maui.Font.SystemFontOfSize(16),
				ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
				CharacterSpacing = 0.5
			};

			string text = "";
			if (this.Exam.ExamEtudiants.Any(examEtudiant => examEtudiant.Etudiant.N_Apo == numeroApp))
            {
                var etudiant =this.Exam.ExamEtudiants.First(examEtudiant => examEtudiant.Etudiant.N_Apo == numeroApp);
                etudiant.IsPresent = true;
				text = $"Valid\nNom : {etudiant.Etudiant.Nom}\nPrenom : {etudiant.Etudiant.Prenom}\nSalle : {etudiant.Salle.Label}\nTable : {etudiant.Table}";
            }
            else
            {
				text = "Non Valid";
				snackbarOptions.TextColor = Colors.Red;
            }
			string actionButtonText = "OK";
			Action action = async () => await Task.CompletedTask;
			TimeSpan duration = TimeSpan.FromSeconds(6);

			var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

			await snackbar.Show(cancellationTokenSource.Token);

        }
		[RelayCommand]
		public async Task SaveExamData()
		{
			this.IsBussy = true;
			ExamDTO exam = new ExamDTO();
			this.Exam.ExamEtudiants.ToList().ForEach(examEtudiant =>
			{
				exam.ExamEtudiants = new List<ExamEtudiantDTO>();
				exam.ExamEtudiants.Add(new ExamEtudiantDTO()
				{
					EtudiantId=(int)examEtudiant.EtudiantId,
					ExamId =(int)examEtudiant.ExamId,
					IsPresent=examEtudiant.IsPresent,
				});
			});
			this.IsBussy=false;
			try
			{
				ExamDTO newexam = await API.Client.ExamsPUTAsync(exam);
				if (newexam != null)
					await Shell.Current.DisplayAlert("Message", "Sauvgarde succes", "OK");
			}catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("Error", "Couldnt save\ntry again ", "OK");
			}
		}
    }
}
