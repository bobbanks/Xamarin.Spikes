using System;
using Xamarin.Forms;

[assembly: Dependency (typeof(Spikes.Droid.BaseUrl_Android))]

namespace Spikes.Droid
{
	public class BaseUrl_Android : IBaseUrl
	{
		public string Get ()
		{
			return "file:///android_asset/";
		}
	}
}

