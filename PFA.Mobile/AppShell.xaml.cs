using PFA.Mobile.Services;
using PFA.Mobile.ViewModels;

namespace PFA.Mobile
{
	public partial class AppShell : Shell
	{
        public ExamDetailsViewModel ExamDetailsViewModel { get; set; }
        public AppShell(Exam selectedExam)
		{
			InitializeComponent();
			this.ExamDetailsViewModel = new(selectedExam);
			this.BindingContext = this;
		}
	}
}