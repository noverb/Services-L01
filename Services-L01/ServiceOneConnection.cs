using Android.Content;
using Android.OS;

namespace Services_L01
{
    class ServiceOneConnection : Java.Lang.Object, IServiceConnection
    {
        MainActivity mainActivity; // OJO!!!

        public ServiceOneConnection (MainActivity activity)
        {
            IsConnected = false;
            TheBinder = null;
            mainActivity = activity;
        }

        public bool IsConnected { get; private set; }

        public ServiceOneBinder TheBinder { get; private set; }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            TheBinder = service as ServiceOneBinder;
            IsConnected = this.TheBinder != null;

            if (IsConnected)
            {
                // Somehow notify the main UI that we are connected
                // mainActivity.UpdateUiForBoundService();
            }
            else
            {

            }
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            IsConnected = false;
            TheBinder = null;
        }

        // LAST BUT NOT LEAST
        public string GetWhatsGoingOn()
        {
            if (!IsConnected) return null;

            return TheBinder?.Service.WhatIsGoingOn();
        }

    }
}