using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Diagnostics;

namespace CreatingMobileAppsSamples.ViewModels
{
	public class VerticalOptionsViewModel : BindableBase, INavigationAware
	{
		readonly INavigationService _navigationService;

		public VerticalOptionsViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
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
