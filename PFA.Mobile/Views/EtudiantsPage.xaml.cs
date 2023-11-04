using PFA.Mobile.ViewModels;

namespace PFA.Mobile.Views;

public partial class EtudiantsPage : ContentPage
{
	public ExamDetailsViewModel ExamDetailsViewModel => (ExamDetailsViewModel)this.BindingContext;
    public bool IsAlreadyDisplay { get; set; }
    public EtudiantsPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		this.ExamDetailsViewModel.ExamEtudiants.Clear();
		this.ExamDetailsViewModel.Exam.ExamEtudiants.ToList().ForEach(ee =>
		{
			this.ExamDetailsViewModel.ExamEtudiants.Add(ee);
		});
	}
}