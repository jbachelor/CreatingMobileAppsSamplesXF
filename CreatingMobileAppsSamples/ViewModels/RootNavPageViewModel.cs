using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Diagnostics;

namespace CreatingMobileAppsSamples.ViewModels
{
	public class RootNavPageViewModel : BindableBase, INavigationAware
	{
		public RootNavPageViewModel()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(RootNavPageViewModel)}:  ctor");
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
	}
}
