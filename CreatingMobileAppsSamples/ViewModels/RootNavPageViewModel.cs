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
			SubscribeToEvents();
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

		bool ShouldHandlePageAppearingAndDisappearingEvents(string pageName)
		{
			return string.Equals(Constants.RootNavigationPageName, pageName, StringComparison.OrdinalIgnoreCase);
		}

		void OnPageAppearing(string pageName)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnPageAppearing)}:  {pageName}");
			SubscribeToEvents();
		}

		void OnPageDisappearing(string pageName)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnPageDisappearing)}:  {pageName}");
			UnsubscribeFromEvents();
		}
	}
}
