using CommunityToolkit.Maui.Views;
using PFA.Mobile.ViewModels;

namespace PFA.Mobile.Views;

public partial class ValidateWithAppPage : Popup
{
    public ExamDetailsViewModel ExamDetailsViewModel { get; set; }
	Action OnClose;
    public ValidateWithAppPage(ExamDetailsViewModel examDetailsViewModel, Action onClose)
	{
		InitializeComponent();
		this.ExamDetailsViewModel = examDetailsViewModel;
		this.OnClose = onClose;
		
	}
	protected override void OnDismissedByTappingOutsideOfPopup()
	{
		this.OnClose?.Invoke();
	}
	private void Validate_Clicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(NumeroApp.Text))
			return;
		this.ExamDetailsViewModel.VerifyEtudiant(NumeroApp.Text);
	}
}