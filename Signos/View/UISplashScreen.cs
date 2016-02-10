using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Signos
{
	public class UISplashScreen : ContentPage
	{
		private string SplashBGResource = "splash_bg.jpg";

		async protected override void OnAppearing ()
		{
			base.OnAppearing ();

			InitComponents ();

			await GoToCarouselAsync ();
		}

		public void InitComponents ()
		{
			BackgroundColor = Color.White;

			Label labelLarge = new Label {
				Text = "Signos",
				FontSize = 80,
				TextColor = Color.White,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			Image image = new Image {
				Source = SplashBGResource,
				Aspect = Aspect.Fill
			};

			RelativeLayout layout = new RelativeLayout ();

			layout.Children.Add (image, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			layout.Children.Add (labelLarge, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			this.Content = new StackLayout {
				Children = {
					layout
				}
			};
		}

		private async Task GoToCarouselAsync ()
		{
			await RestAPI.Instance.RefreshDataAsync ();
			App.Current.MainPage = new Carousel ();
		}
	}
}

