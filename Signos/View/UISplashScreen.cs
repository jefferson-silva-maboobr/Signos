using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Zodiaco
{
	public class UISplashScreen : ContentPage
	{
		private string SplashBGResource = "splash.png";

		async protected override void OnAppearing ()
		{
			base.OnAppearing ();

			InitComponents ();

			await GoToCarouselAsync ();
		}

		public void InitComponents ()
		{
			Image image = new Image {
				Source = SplashBGResource,
				Aspect = Aspect.AspectFit,
			};

			this.Content = new StackLayout {
				Children = {
					image
				}
			};
		}

		private async Task GoToCarouselAsync ()
		{
			await RestAPI.Instance.RefreshDataAsync ();
			//App.Current.MainPage = new UICarousel ();
			App.Current.MainPage = new UIPanel ();
		}
	}
}

