using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA.Mobile.Services
{
	public static class API
	{
		public static Client Client = new("https://a1a7-105-67-133-95.ngrok-free.app", new HttpClient());
	}
}
