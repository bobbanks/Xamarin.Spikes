using System;
using MonoTouch.Foundation;
using Xamarin.Forms;

[assembly: Dependency (typeof(Spikes.iOS.BaseUrl_iOS))]

namespace Spikes.iOS
{
	public class BaseUrl_iOS : IBaseUrl
	{
		public string Get ()
		{
			return NSBundle.MainBundle.PathForResource ("article", "pdf");
			return NSUrl.FromString (NSBundle.MainBundle.BundlePath).AbsoluteString;
		}
	}
}

