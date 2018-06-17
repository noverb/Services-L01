using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Services_L01
{
    [Service]
    [IntentFilter (new String[] { "com.xamarin.Services_Lessons" } )]
    public class ServiceOneService : Service
    {
        public IBinder myBinder { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();
            Toast.MakeText(this, "Creating Service... ", ToastLength.Short).Show();
        }

        public override IBinder OnBind(Intent intent)
        {
            Toast.MakeText(this, "Binding Service to Client... ", ToastLength.Short).Show();
            this.myBinder = new ServiceOneBinder(this);
            return myBinder;
        }

        public override void UnbindService(IServiceConnection conn)
        {
            if (conn != null)
            {
                base.UnbindService(conn);
                Toast.MakeText(this, "UnBinding Service from Client... ", ToastLength.Short).Show();

            }
            else
            Toast.MakeText(this, "OJO - Couldn't UnBind Service from Client... ", ToastLength.Short).Show();
        }

        /// <summary>
        /// This is one of many methods that can be made accessible as part of the SERVICE
        /// 
        /// This method just informs what it is doing via a String object
        /// </summary>
        public string WhatIsGoingOn()
        {
            Toast.MakeText(this, "You touched the Service activation button... ", ToastLength.Short).Show();
            return "This is what the service would return to you... ";
        }
    }
}