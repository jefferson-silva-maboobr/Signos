using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Signos
{
	public class Carousel : CarouselPage
	{
		public Carousel()
		{
			BuildView (GetData ());
		}

		private List<SignoItem> GetData ()
		{
			return SignoItemVM.Instance.GetSignosAsync ();
		}

		private void BuildView (List<SignoItem> signos)
		{
			foreach (SignoItem signo in signos) {
				Children.Add (new UICarouselItem(signo.id));
			}
		}
    }
}

