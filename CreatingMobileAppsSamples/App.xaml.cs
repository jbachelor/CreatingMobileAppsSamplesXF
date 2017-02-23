using Prism.Unity;
using CreatingMobileAppsSamples.Views;

namespace CreatingMobileAppsSamples
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync($"{nameof(RootNavPage)}/{nameof(MainPage)}");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<RootNavPage>();
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<VerticalOptions>();
		}
	}
}

