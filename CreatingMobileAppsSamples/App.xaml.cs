using Prism.Unity;
using Prism.Events;
using Microsoft.Practices.Unity;
using CreatingMobileAppsSamples.Views;
using System.Diagnostics;
using System;
using CreatingMobileAppsSamples.Services;
using Prism.Services;

namespace CreatingMobileAppsSamples
{
	public partial class App : PrismApplication
	{
		IEventAggregator _eventAggregator;
		IPageDialogService _pageDialogService;

		bool monitorForShakes = true;

		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnInitialized)}");

			InitializeComponent();
			InitializeApp();
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

		void InitializeApp()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(InitializeApp)}");
			_eventAggregator = Container.Resolve<IEventAggregator>();
			_pageDialogService = Container.Resolve<IPageDialogService>();

			_eventAggregator.GetEvent<ShakeGestureDetectedEvent>().Subscribe(OnShakeGestureDetected);
			_eventAggregator.GetEvent<AllowShakeDetectionEvent>().Subscribe(OnToggleShakeDetection);
		}

		void OnToggleShakeDetection(bool shouldMonitorForShakeGesture)
		{
			monitorForShakes = shouldMonitorForShakeGesture;
		}

		async void OnShakeGestureDetected()
		{
			if (monitorForShakes)
			{
				Debug.WriteLine($"{this.GetType().Name}.{nameof(OnShakeGestureDetected)}");
				monitorForShakes = false;
				await _pageDialogService.DisplayAlertAsync("Shaken, not stirred", "You shook me alllll niiiiight loooong!", "ok");
				monitorForShakes = true;
			}
		}
	}
}

