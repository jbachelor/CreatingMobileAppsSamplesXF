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
	public class VerticalOptionsPageViewModel : BindableBase, INavigationAware
	{
		readonly INavigationService _navigationService;
		readonly IEventAggregator _eventAggregator;

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}


		public VerticalOptionsPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(VerticalOptionsPageViewModel)}:  ctor");
			_eventAggregator = eventAggregator;
			_navigationService = navigationService;
			Title = "Vertical Options";

			SubscribeToEvents();
		}

		~VerticalOptionsPageViewModel()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(VerticalOptionsPageViewModel)}:  Destructor");
		}

		void SubscribeToEvents()
		{
			UnsubscribeFromEvents();

			Debug.WriteLine($"{this.GetType().Name}.{nameof(SubscribeToEvents)}");

			_eventAggregator.GetEvent<PageAppearingEvent>().Subscribe(OnPageAppearing, ThreadOption.UIThread, true, ShouldHandlePageAppearingAndDisappearingEvents);
			_eventAggregator.GetEvent<PageDisappearingEvent>().Subscribe(OnPageDisappearing, ThreadOption.UIThread, true, ShouldHandlePageAppearingAndDisappearingEvents);
		}

		void UnsubscribeFromEvents()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(UnsubscribeFromEvents)}");

			_eventAggregator.GetEvent<PageAppearingEvent>().Unsubscribe(null);
			_eventAggregator.GetEvent<PageDisappearingEvent>().Unsubscribe(null);
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedFrom)}");
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedTo)}");
		}

		bool ShouldHandlePageAppearingAndDisappearingEvents(string pageName)
		{
			return string.Equals(Constants.VerticalOptionsPageName, pageName, StringComparison.OrdinalIgnoreCase);
		}

		void OnPageAppearing(string pageName)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnPageAppearing)}:  {pageName}");
			SubscribeToEvents();
		}

		void OnPageDisappearing(string pageName)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnPageDisappearing)}");
			UnsubscribeFromEvents();
		}
	}
}
