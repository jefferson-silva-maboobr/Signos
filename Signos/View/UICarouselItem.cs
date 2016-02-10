using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Signos
{
	public class UICarouselItem : ContentPage
	{
		private int _signoId;
		private SignoItem _signo;

		private RelativeLayout _cardLayout;
		private Label _message;

		public UICarouselItem (int id)
		{
			_signoId = id;
			_signo = SignoItemVM.Instance.GetSigno (_signoId);

			InitComponents ();
		}

		public void InitComponents ()
		{
			BackgroundColor = Color.White;

			_message = new Label {
				FontSize = 40,
				TextColor = Color.White,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			Image boxView = new Image {
				Source = new FileImageSource () { File = "splash_bg.jpg" },
				Aspect = Aspect.AspectFill,
				IsOpaque = true,
				Opacity = 0.8
			};

			Image image = new Image {
				Source = new FileImageSource () { File = _signo.imageURI },
				Aspect = Aspect.AspectFill,
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {
				ShowAlertMessage (s, e);
			};
			image.GestureRecognizers.Add (tapGestureRecognizer);

			RelativeLayout backgroundLayout = new RelativeLayout ();
			backgroundLayout.Children.Add (image, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			_cardLayout = new RelativeLayout ();
			_cardLayout.IsVisible = false;

			_cardLayout.Children.Add (boxView, 
				Constraint.Constant (0.0), 
				Constraint.Constant (0.0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width ;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			_cardLayout.Children.Add (_message, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			backgroundLayout.Children.Add (_cardLayout, 
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2 - _cardLayout.Width / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2 - _cardLayout.Height / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 1.2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2;
				}));

			this.Content = new StackLayout {
				Children = {
					backgroundLayout
				}
			};
		}

		void ShowAlertMessage (object sender, EventArgs e)
		{
			if (_cardLayout.IsVisible) {
				_cardLayout.IsVisible = false;
			} else {
				string msg = _signo.message;
				_message.Text = msg;
				_cardLayout.IsVisible = true;
			}
		}
	}
}

