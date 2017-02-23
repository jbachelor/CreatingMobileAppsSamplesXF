using Prism.Unity;
using Prism.Events;
using Microsoft.Practices.Unity;
using CreatingMobileAppsSamples.Views;
using System.Diagnostics;
using System;
using CreatingMobileAppsSamples.Services;

namespace CreatingMobileAppsSamples
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnInitialized)}");

			InitializeComponent();
			NavigationService.NavigateAsync($"{nameof(RootNavPage)}/{nameof(MainPage)}");
		}

		protected override void RegisterTypes()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RegisterTypes)}");

			RegisterTypesForNavigation();
			RegisterGlobals();
		}

		void RegisterTypesForNavigation()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RegisterTypesForNavigation)}");

			Container.RegisterTypeForNavigation<RootNavPage>();
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<VerticalOptionsPage>();
		}

		void RegisterGlobals()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RegisterGlobals)}");

			Globals.GlobalEventAggregator = Container.Resolve<IEventAggregator>();
		}
	}
}

