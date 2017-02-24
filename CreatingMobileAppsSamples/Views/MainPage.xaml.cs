using System.Diagnostics;
using Xamarin.Forms;
using CreatingMobileAppsSamples.Services;

namespace CreatingMobileAppsSamples.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(MainPage)}:  ctor");
			InitializeComponent();
		}

		~MainPage()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(MainPage)}:  Destructor");
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

