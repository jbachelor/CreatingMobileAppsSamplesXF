using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CreatingMobileAppsSamples.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public MainPageViewModel()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

			Title = "I'm the main page!";
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
	}
}

