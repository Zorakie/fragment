using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace cv5_fragment
{
    [Activity(Label = "cv5_fragment", MainLauncher = true, Icon = "@drawable/icon")]


    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);



			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.MyButton);

			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};

			// Create a new fragment and a transaction.
			FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction ();
			Fragment1 aDifferentDetailsFrag = new Fragment1 ();

			// The fragment will have the ID of Resource.Id.fragment_container.
			fragmentTx.Add (Resource.Id.fragment_container, aDifferentDetailsFrag);

			// Commit the transaction.
			fragmentTx.Commit ();
		}

    }
}

