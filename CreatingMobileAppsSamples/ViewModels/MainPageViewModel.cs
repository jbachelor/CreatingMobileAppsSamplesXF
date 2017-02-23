using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using CreatingMobileAppsSamples.Views;

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

		public MainPageViewModel(INavigationService navigationService)
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

			_navigationService = navigationService;
			NavToVerticalOptionsCommand = new DelegateCommand(OnNavToVerticalOptions);
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
			_navigationService.NavigateAsync(nameof(VerticalOptions));
		}
	}
}

