using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using CreatingMobileAppsSamples.Views;
using Prism.Events;
using CreatingMobileAppsSamples.Services;

namespace CreatingMobileAppsSamples.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		public DelegateCommand NavToVerticalOptionsCommand { get; set; }

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		INavigationService _navigationService;
		readonly IEventAggregator _eventAggregator;

		public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

			_eventAggregator = eventAggregator;
			_navigationService = navigationService;

			NavToVerticalOptionsCommand = new DelegateCommand(OnNavToVerticalOptions);

			Title = "DEMOS";

			SetupSubscriptions();
		}

		~MainPageViewModel()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(MainPageViewModel)}:  Destructor");
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedFrom)}");
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedTo)}");
		}

		void OnNavToVerticalOptions()
		{
			_navigationService.NavigateAsync(nameof(VerticalOptionsPage));
		}

		void SetupSubscriptions()
		{
			_eventAggregator.GetEvent<PageAppearingEvent>().Subscribe(OnPageAppearing, ThreadOption.UIThread, true, ShouldHandlePageAppearingEvent);
		}

		bool ShouldHandlePageAppearingEvent(string pageName)
		{
			return string.Equals(Constants.MainPageName, pageName, StringComparison.OrdinalIgnoreCase);
		}

		void OnPageAppearing(string pageName)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(OnPageAppearing)}:  {pageName}");
		}
	}
}

