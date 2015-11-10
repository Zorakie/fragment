using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.ComponentModel;



using System.Collections.Generic;


using System.Drawing;

using System.Linq;
using System.Text;

using System.Runtime.InteropServices;



using System.Diagnostics;
using System.Security.Permissions;
using System.Threading.Tasks;

using System.Net.Sockets;

namespace cv5_fragment
{
    public class Fragment1 : Fragment
    {


        Button btnOK;
        Button btnZrus;
        EditText name;
        EditText phone;
        EditText email;
        EditText adress;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           var view = inflater.Inflate(Resource.Layout.Fragment2, container, false);
           



            btnOK = view.FindViewById<Button>(Resource.Id.button1);
            btnZrus = view.FindViewById<Button>(Resource.Id.button2);
            name = view.FindViewById<EditText>(Resource.Id.txtName);
            adress = view.FindViewById<EditText>(Resource.Id.txtAdress);
            phone = view.FindViewById<EditText>(Resource.Id.txtTel);
            email = view.FindViewById<EditText>(Resource.Id.txtEmail);




          

            btnOK.Click += delegate { Validatemy(); };
            btnZrus.Click += delegate {  };

            return view;
        }


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));

        }



        private void Validatethread()
        {
            Thread tr = new Thread(() =>
            {
                Validatemy();
            });
            tr.Start();

        }
        private void Validatemy()
        {

            string validate = "";
            if (name.Text == "") { validate += "Zadejte jmeno \n"; }
            try
            {

                int phonenumber = Convert.ToInt32(phone.Text);
                if (phone.Length() != 13) { validate += "Cislo neni v mezinarodnim tvaru \n"; }


            }
            catch { validate += "Cislo neni zadano nebo obsahuje invalidni znaky\n"; }
            if (!ValidateEmail()) { validate += "Invalidni email \n"; }

           
            if (validate == "") {
                Toast.MakeText(this.Activity, "OK", ToastLength.Long).Show();  }
            else {  Toast.MakeText(this.Activity, validate, ToastLength.Long).Show();  }

        }


        private bool ValidateEmail()
        {
            if (!email.Text.Contains("@")) { return false; }
            bool roll = true;
            bool isroll = false;
            for (int i = 0; i < email.Length(); i++)
            {
                if (email.Text[i].ToString() == "@")
                {
                    if (isroll == false) { isroll = true; }
                    else { roll = false; }
                }

            }
            if (!roll) { return false; }
            int arrayindex = email.Length();
            if (arrayindex == 0) { return false; }
            if (arrayindex <= 5) { return false; }
            if (Char.IsLetter(email.Text[arrayindex - 1]) && Char.IsLetter(email.Text[arrayindex - 2]) && email.Text[arrayindex - 3].ToString() == "." && email.Text.Contains("@") && !email.Text.Contains("@.")) { return true; }
            else if (Char.IsLetter(email.Text[arrayindex - 1]) && Char.IsLetter(email.Text[arrayindex - 2]) && Char.IsLetter(email.Text[arrayindex - 3]) && email.Text[arrayindex - 4].ToString() == "." && email.Text.Contains("@") && !email.Text.Contains("@.")) { return true; }
            else { return false; }
            return false;

        }













    }
}