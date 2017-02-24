using System.Diagnostics;
using Xamarin.Forms;
using CreatingMobileAppsSamples.Services;

namespace CreatingMobileAppsSamples.Views
{
	public partial class RootNavPage : NavigationPage
	{
		public RootNavPage()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RootNavPage)}:  ctor");
			InitializeComponent();
		}

		~RootNavPage()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RootNavPage)}:  Destructor");
		}

		void OnPageAppearing(object sender, System.EventArgs e)
		{
			Globals.GlobalEventAggregator.GetEvent<PageAppearingEvent>().Publish(this.GetType().Name);
		}

		void OnPageDisappearing(object sender, System.EventArgs e)
		{
			Globals.GlobalEventAggregator.GetEvent<PageDisappearingEvent>().Publish(this.GetType().Name);
		}
	}
}

