using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace Services_L01
{
    [Activity(Label = "Services_L01", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ServiceOneConnection serviceOneConnection;

        protected override void OnStart()
        {
            base.OnStart();
            if (serviceOneConnection == null)
            {
                this.serviceOneConnection = new ServiceOneConnection(this);
                Toast.MakeText(this, "The service has been CREATED", ToastLength.Short).Show();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button Get_btn = FindViewById<Button>(Resource.Id.btn_get);
            Button Bind_btn = FindViewById<Button>(Resource.Id.btn_bind);
            Button UnBind_btn = FindViewById<Button>(Resource.Id.btn_unbind);

            TextView Message_vw = FindViewById<TextView>(Resource.Id.tv_message);

            Message_vw.Text = "The Activity just started. Service not there yet";

            // After the Service was created and the Binder and Connection defined, now we can use them as follows:
            //serviceOneConnection = new ServiceOneConnection(this);
            Intent theServiceToStart = new Intent(this, typeof(ServiceOneService));

            Bind_btn.Click += (s, e) =>
            {
                Message_vw.Text = string.Empty;
                Message_vw.Text = "The service has been BOUND";
                BindService(theServiceToStart, serviceOneConnection, Bind.AutoCreate);
            };

            UnBind_btn.Click += (s, e) =>
            {
                if (serviceOneConnection != null)
                {
                    Message_vw.Text = string.Empty;
                    Message_vw.Text = "The service has been UNBOUND";
                    UnbindService(serviceOneConnection);
                }
                else
                {
                    Message_vw.Text = string.Empty;
                    Message_vw.Text = "Couldn't UnBind service - Connection is null";
                }
            };

            Get_btn.Click += (s, e) =>
            {
                Message_vw.Text = String.Empty;
                Message_vw.Text = serviceOneConnection.GetWhatsGoingOn();
            };
        }

    }
}

