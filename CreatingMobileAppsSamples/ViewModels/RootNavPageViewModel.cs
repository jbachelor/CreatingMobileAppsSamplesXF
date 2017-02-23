using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Diagnostics;
using CreatingMobileAppsSamples.Services;

namespace CreatingMobileAppsSamples.ViewModels
{
	public class RootNavPageViewModel : BindableBase, INavigationAware
	{
		readonly IEventAggregator _eventAggregator;

		public RootNavPageViewModel(IEventAggregator eventAggregator)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RootNavPageViewModel)}:  ctor");

			_eventAggregator = eventAggregator;
			SetupSubscriptions();
		}

		~RootNavPageViewModel()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RootNavPageViewModel)}:  Desctructor");
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedFrom)}");
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedTo)}");
		}

		void SetupSubscriptions()
		{
			_eventAggregator.GetEvent<PageAppearingEvent>().Subscribe(OnPageAppearing, ThreadOption.UIThread, true, ShouldHandlePageAppearingEvent);
		}

		bool ShouldHandlePageAppearingEvent(string pageName)
		{
			return string.Equals(Constants.RootNavigationPageName, pageName, StringComparison.OrdinalIgnoreCase);
		}

		void OnPageAppearing(string pageName)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnPageAppearing)}:  {pageName}");
		}
	}
}
