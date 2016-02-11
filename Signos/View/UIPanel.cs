using System;

using Xamarin.Forms;
using System.Collections.Generic;
using Signos;
using System.Threading.Tasks;

namespace Zodiaco
{
	public class UIPanel : ContentPage
	{
		StackLayout _cardLayout;
		private Label _message;
		private Label _titleCardHeader;
		private RelativeLayout _backgroudHeader;

		public UIPanel ()
		{
			BuildView (GetData ());
		}

		private List<SignoItem> GetData ()
		{
			return SignoItemVM.Instance.GetSignosAsync ();
		}

		private void BuildView (List<SignoItem> signos)
		{

			/******************************************
			* Header
			******************************************/
			Image headerIcon = new Image {
				Source = new FileImageSource () { File = "logo_zodiaco.png" },
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Transparent,
				WidthRequest = 75,
				HeightRequest = 75,
			};

			/******************************************
			* Grid
			******************************************/
			Grid grid = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowSpacing = -100,
				ColumnSpacing = -50,
			};
			var HideCardGestureRecognizer = new TapGestureRecognizer ();
			HideCardGestureRecognizer.Tapped += (s, e) => {
				HideCardMessage (s, e);
			};
			grid.GestureRecognizers.Add (HideCardGestureRecognizer);

			/******************************************
			* Screen layout
			******************************************/
			RelativeLayout screenLayout = new RelativeLayout ();
			screenLayout.Children.Add (grid, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			/******************************************
			* Card Message
			******************************************/
			_titleCardHeader = new StyledLabel {
				FontSize = 30,
				TextColor = Color.White,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				Style = StyleType.Bold
			};

			_backgroudHeader = new RelativeLayout ();
			_backgroudHeader.BackgroundColor = Color.Red;
			_backgroudHeader.Children.Add (_titleCardHeader, 
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2 - _titleCardHeader.Width / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 5;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 45;
				}));

			_message = new Label {
				FontSize = 12,
				TextColor = Color.Gray,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			RelativeLayout _cardMessageInside = new RelativeLayout ();
			_cardMessageInside.BackgroundColor = Color.White;
			_cardMessageInside.GestureRecognizers.Add (HideCardGestureRecognizer);

			_cardMessageInside.Children.Add (_message, 
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width / 2) - (_message.Width / 2);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height / 2) - (_message.Height / 2);
				}),
				Constraint.RelativeToParent ((parent) => {
					return 260;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 120;
				}));

			_cardLayout = new StackLayout ();
			_cardLayout.IsVisible = false;
			_cardLayout.Children.Add (_backgroudHeader);
			_cardLayout.Children.Add (_cardMessageInside);
			_cardLayout.Spacing = 0;

			screenLayout.Children.Add (_cardLayout, 
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2 - _cardLayout.Width / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 120;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 1.3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 5;
				}));

			int countPos = 0;
			int[][] pos = new int[][] {
				new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { 2, 0 },
				new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 2, 1 },
				new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 2, 2 },
				new int[] { 0, 3 }, new int[] { 1, 3 }, new int[] { 2, 3 },
			};

			/******************************************
			* Create and put items in grid
			******************************************/
			foreach (SignoItem signo in signos) {
				string name = signo.name.Split ("".ToCharArray ()) [0];
				Label label = new Label {
					Text = name,
					FontSize = 16,
					TextColor = Color.FromHex ("#" + signo.color),
					BackgroundColor = Color.Transparent,
					XAlign = TextAlignment.Center,
					YAlign = TextAlignment.Center,
				};

				Image image = new Image {
					Source = new FileImageSource () { File = signo.imageURI },
					Aspect = Aspect.AspectFit,
					WidthRequest = 85,
					HeightRequest = 75
				};
				var showCardGestureRecognizer = new TapGestureRecognizer ();
				showCardGestureRecognizer.Tapped += (s, e) => {
					ShowCardMessage (s, e, signo);
				};
				image.GestureRecognizers.Add (showCardGestureRecognizer);

				StackLayout itemLayout = new StackLayout ();
				itemLayout.Children.Add (image);
				itemLayout.Children.Add (label);
				grid.Children.Add (itemLayout, pos [countPos] [0], pos [countPos] [1]);

				countPos++;
			}

			/******************************************
			* Mount view
			******************************************/
			this.Content = new StackLayout {
				Children = {
					headerIcon,
					screenLayout
				},
				Spacing = 20,
				Padding = new Thickness (0, 10, 0, 20),
				BackgroundColor = Color.FromHex ("#464646")
			};
		}

		void ShowCardMessage (object sender, EventArgs e, SignoItem signo)
		{
			if (_cardLayout.IsVisible) {
				HideCardMessage (sender, e);
				return;
			}

			_message.Text = signo.message;
			_titleCardHeader.Text = signo.name.Split ("".ToCharArray ()) [0];
			_backgroudHeader.BackgroundColor = Color.FromHex ("#" + signo.color);
			_cardLayout.IsVisible = true;
		}

		void HideCardMessage (object sender, EventArgs e)
		{
			_cardLayout.IsVisible = false;
		}
	}
}


