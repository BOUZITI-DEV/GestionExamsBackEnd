using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA.Mobile.ViewModels
{
	public partial class BaseViewModel:ObservableObject
	{
		[ObservableProperty]
		bool isBussy;
		public bool IsNotBussy => !this.IsBussy;
    }
}
