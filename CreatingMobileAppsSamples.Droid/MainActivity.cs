using System;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Android.Hardware;
using CreatingMobileAppsSamples.Services;

namespace CreatingMobileAppsSamples.Droid
{
	[Activity(Label = "CreatingMobileAppsSamples.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, ISensorEventListener
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			// Shake gesture handler code
			var sensorManager = GetSystemService(SensorService) as SensorManager;
			var sensor = sensorManager.GetDefaultSensor(SensorType.Accelerometer);
			sensorManager.RegisterListener(this, sensor, SensorDelay.Game);
			// End shake gesture handler code

			LoadApplication(new App(new AndroidInitializer()));
		}

		#region Handling Shake Gesture

		bool hasUpdated = false;
		DateTime lastUpdate;
		float last_x = 0.0f;
		float last_y = 0.0f;
		float last_z = 0.0f;

		const int ShakeDetectionTimeLapse = 250;
		const double ShakeThreshold = 800;


		public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
		{
			System.Diagnostics.Debug.WriteLine($"{this.GetType().Name}.{nameof(OnAccuracyChanged)}:  No-op.");
		}

		public void OnSensorChanged(SensorEvent e)
		{
			if (e.Sensor.Type == SensorType.Accelerometer)
			{
				float x = e.Values[0];
				float y = e.Values[1];
				float z = e.Values[2];

				DateTime curTime = System.DateTime.Now;
				if (hasUpdated == false)
				{
					hasUpdated = true;
					lastUpdate = curTime;
					last_x = x;
					last_y = y;
					last_z = z;
				}
				else
				{
					if ((curTime - lastUpdate).TotalMilliseconds > ShakeDetectionTimeLapse)
					{
						float diffTime = (float)(curTime - lastUpdate).TotalMilliseconds;
						lastUpdate = curTime;
						float total = x + y + z - last_x - last_y - last_z;
						float speed = Math.Abs(total) / diffTime * 10000;

						if (speed > ShakeThreshold)
						{
							//Toast.MakeText(this, "shake detected w/ speed: " + speed, ToastLength.Short).Show();
							Globals.GlobalEventAggregator.GetEvent<ShakeGestureDetectedEvent>().Publish();
						}

						last_x = x;
						last_y = y;
						last_z = z;
					}
				}
			}
		}

		#endregion

	}

	public class AndroidInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IUnityContainer container)
		{

		}
	}
}
