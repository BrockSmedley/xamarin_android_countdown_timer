﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CountDownTimerDemo {
	[Activity(Label = "CountDownTimerDemo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity {
		//timer logic vars
		CountDownTimer countDownTimer;
		bool isTimerRunning = false;
		int duration;
		int interval;

		//view instances
		Button button;
		TextView textView;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			//set timer vars
			duration = 15000;
			interval = 500;

			//get a new timer object
			countDownTimer = new CTimer(duration, interval, OnTick, OnFinish);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			button = FindViewById<Button>(Resource.Id.MyButton);
			textView = FindViewById<TextView>(Resource.Id.textView1);

			//start timer on button press
			button.Click += delegate {
				if (!isTimerRunning) {
					isTimerRunning = true;
					countDownTimer.Start();
				}
			};
		}

		#region CountDownTimer delegate functions

		//(delegated) event methods for timer
		public void OnTick(long millisUntilFinished) {
			if (millisUntilFinished % 1000 > interval || millisUntilFinished > (duration - interval)) {
				int outputTime = (int)Math.Round(millisUntilFinished * 0.001);
				textView.SetText(outputTime.ToString(), TextView.BufferType.Normal);
			}
		}
		public void OnFinish() {
			textView.SetText("Finished", TextView.BufferType.Normal);
			isTimerRunning = false;
		}

		#endregion
	}
}

