using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;
using System;
using Prism.Navigation;
using CreatingMobileAppsSamples.Services;

namespace CreatingMobileAppsSamples.Views
{
	public partial class VerticalOptionsPage : ContentPage
	{
		public VerticalOptionsPage()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(VerticalOptionsPage)}:  ctor");
			InitializeComponent();
			SetupView();
		}

		~VerticalOptionsPage()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(VerticalOptionsPage)}:  Destructor");
		}

		void OnPageAppearing(object sender, System.EventArgs e)
		{
			Globals.GlobalEventAggregator.GetEvent<PageAppearingEvent>().Publish(this.GetType().Name);
		}

		void OnPageDisappearing(object sender, System.EventArgs e)
		{
			Globals.GlobalEventAggregator.GetEvent<PageDisappearingEvent>().Publish(this.GetType().Name);
		}

		void SetupView()
		{
			Debug.WriteLine($"{this.GetType().Name}.{nameof(SetupView)}");

			Color[] colors = { Color.Yellow, Color.Blue };
			int flipFlopper = 0;

			IEnumerable<Label> labels =
				from field in typeof(LayoutOptions).GetRuntimeFields()
				where field.IsPublic && field.IsStatic
				orderby ((LayoutOptions)field.GetValue(null)).Alignment
				select new Label
				{
					Text = "VerticalOptions = " + field.Name,
					VerticalOptions = (LayoutOptions)field.GetValue(null),
					HorizontalTextAlignment = TextAlignment.Center, // centers text horizontally within label
					VerticalTextAlignment = TextAlignment.Center,   // centers text vertically within label
					FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
					TextColor = colors[flipFlopper],
					BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
				};

			StackLayout stackLayout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Spacing = 5,
				BackgroundColor = Color.Silver
			};

			foreach (var label in labels)
			{
				Debug.WriteLine($"--- {this.GetType().Name}.{nameof(SetupView)}:  Adding label:  {label.Text}{Environment.NewLine}\tVerticalTextAlignment:  {label.VerticalTextAlignment}{Environment.NewLine}\tHorizontalTextAlignment:  {label.HorizontalTextAlignment}{Environment.NewLine}");
				stackLayout.Children.Add(label);
			}

			Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

			Content = stackLayout;
		}
	}
}

