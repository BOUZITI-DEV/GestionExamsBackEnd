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
	internal partial class HomePageViewModel:BaseViewModel
	{
		public ObservableCollection<Exam> Exams { get; set; } = new();
        [ObservableProperty,NotifyPropertyChangedFor(nameof(IsContinueEnabled))]
        Exam selectedExam;
        public bool IsContinueEnabled => this.SelectedExam != null;
        public Surveillant Surveillant { get; set; }
        public HomePageViewModel(Surveillant surveillant)
        {
            this.Surveillant = surveillant;
            Initialize();
        }
        private async Task Initialize()
        {
            //TODO : will load from api
            this.Surveillant.ExamSurveillants.ToList().ForEach(examsurveillant =>
            {
                this.Exams.Add(new Exam()
                {
                    Label = examsurveillant.Exam.Label,
                    DateDebut = examsurveillant.Exam.DateDebut,
                    DateFin = examsurveillant.Exam.DateFin,
                    ExamEtudiants=examsurveillant.Exam.ExamEtudiants,
				});
            });
        }
        [RelayCommand]
        public async Task Continue()
        {
            Application.Current.MainPage = new AppShell(this.SelectedExam);
            await Task.CompletedTask;
        }
        [RelayCommand]
        public async Task Cancel()
        {
            Application.Current.MainPage = new LoginPage();
			await Task.CompletedTask;
        }
    }
}
