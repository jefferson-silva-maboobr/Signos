using System;

using Xamarin.Forms;
using System.Collections.Generic;
using Signos;
using System.Threading.Tasks;

namespace Zodiaco
{
	public class UIPanel : ContentPage
	{
		private Label _message;
		private Label _titleCardHeader;
		private RelativeLayout _cardHeader;
		private RelativeLayout _blackMirror;

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
			* Screen layout with grid
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
			* Black mirror all screen
			******************************************/
			_blackMirror = new RelativeLayout ();
			_blackMirror.IsVisible = false;
			_blackMirror.GestureRecognizers.Add (HideCardGestureRecognizer);

			Image cardShadowBG = new Image();
			cardShadowBG.Aspect = Aspect.Fill;
			cardShadowBG.Source =  new FileImageSource () { File = "window_shadow.png" };

			_blackMirror.Children.Add (cardShadowBG, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			/******************************************
			* Title Card
			******************************************/
			_titleCardHeader = new StyledLabel {
				FontSize = 30,
				TextColor = Color.White,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				Style = StyleType.Bold
			};

			_cardHeader = new RelativeLayout ();
			_cardHeader.BackgroundColor = Color.Transparent;

			Image titleCardBG = new Image();
			titleCardBG.Aspect = Aspect.AspectFit;
			titleCardBG.Source =  new FileImageSource () { File = "card_title.png" };

			_cardHeader.Children.Add (titleCardBG, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 55;
				}));

			_cardHeader.Children.Add (_titleCardHeader, 
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

			/******************************************
			* Message Card
			******************************************/
			_message = new Label {
				FontSize = 12,
				TextColor = Color.Gray,
				XAlign = TextAlignment.Start,
				YAlign = TextAlignment.Center
			};

			RelativeLayout _cardMessage = new RelativeLayout ();
			_cardMessage.BackgroundColor = Color.Transparent;

			Image messageCardBG = new Image();
			messageCardBG.Aspect = Aspect.Fill;
			messageCardBG.Source =  new FileImageSource () { File = "card_msg.png" };

			_cardMessage.Children.Add (messageCardBG, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			_cardMessage.Children.Add (_message, 
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

			/******************************************
			* Card
			******************************************/
			StackLayout cardLayout = new StackLayout ();
			cardLayout.Children.Add (_cardHeader);
			cardLayout.Children.Add (_cardMessage);
			cardLayout.Spacing = 0;

			_blackMirror.Children.Add (cardLayout, 
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2 - cardLayout.Width / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 180;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 1.3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3;
				}));

			/******************************************
			* Create and put items in grid
			******************************************/
			int countPos = 0;
			int[][] pos = new int[][] {
				new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { 2, 0 },
				new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 2, 1 },
				new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 2, 2 },
				new int[] { 0, 3 }, new int[] { 1, 3 }, new int[] { 2, 3 },
			};

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
			* Scene = header and grid
			******************************************/
			StackLayout scene = new StackLayout {
				Children = {
					headerIcon,
					screenLayout
				},
				Spacing = 20,
				Padding = new Thickness (0, 10, 0, 20),
				BackgroundColor = Color.FromHex ("#464646")
			};

			/******************************************
			* Scene = header and grid + blackShadow in all screen
			******************************************/
			RelativeLayout sceneFull = new RelativeLayout ();
			sceneFull.Children.Add (scene, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));
			sceneFull.Children.Add (_blackMirror, 
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
					sceneFull
				}
			};
		}

		void ShowCardMessage (object sender, EventArgs e, SignoItem signo)
		{
			if (_blackMirror.IsVisible) {
				HideCardMessage (sender, e);
				return;
			}

			_message.Text = signo.message;
			_titleCardHeader.Text = signo.name.Split ("".ToCharArray ()) [0];
			//_backgroudHeader.BackgroundColor = Color.FromHex ("#" + signo.color);
			_blackMirror.IsVisible = true;
		}

		void HideCardMessage (object sender, EventArgs e)
		{
			_blackMirror.IsVisible = false;
		}
	}
}


