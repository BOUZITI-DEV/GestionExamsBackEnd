using Camera.MAUI;
using CommunityToolkit.Maui.Views;
using PFA.Mobile.ViewModels;

namespace PFA.Mobile.Views;

public partial class ExamDetailsPage : ContentPage
{
    public bool playing { get; set; }
	public bool IsPlaying { get; set; }
	public ExamDetailsViewModel ExamDetailsViewModel => (ExamDetailsViewModel)this.BindingContext;

	public ExamDetailsPage()
	{
		InitializeComponent();
	}
	protected async override void OnAppearing()
	{
		if (IsPlaying)
		{
			await cameraView.StopCameraAsync();
			await cameraView.StartCameraAsync();
		}
	}
	private void cameraView_Loaded(object sender, EventArgs e)
	{
		this.IsPlaying = true;
		if (cameraView.Cameras.Count > 0)
		{
			cameraView.Camera = cameraView.Cameras.First();
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				await cameraView.StopCameraAsync();
				await cameraView.StartCameraAsync();
			});
		}
	}

	private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			this.ExamDetailsViewModel.VerifyEtudiant(args.Result[0].Text);

		});
	}


	private void VerifyWithNumApp_Clicked(object sender, EventArgs e)
	{
		this.cameraView.StopCameraAsync();
		Shell.Current.ShowPopup(new ValidateWithAppPage(this.ExamDetailsViewModel, () =>
		{
			this.cameraView.StartCameraAsync();
		}));
	}
}