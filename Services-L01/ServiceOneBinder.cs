using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Services_L01
{
    public class ServiceOneBinder : Binder
    {
        public ServiceOneBinder(ServiceOneService service)
        {
            this.Service = service;
        }

        public ServiceOneService Service {get; private set;}
    }
}