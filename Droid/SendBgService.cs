
using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace WaterSensor.Droid
{
    [Service(Label = "SendBgService")]
    [IntentFilter(new String[] { "com.yourname.SendBgService" })]
    public class SendBgService : Service
    {
        IBinder binder;

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            // start your service logic here

            // Return the correct StartCommandResult for the type of service you are building
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            binder = new SendBgServiceBinder(this);
            return binder;
        }
    }

    public class SendBgServiceBinder : Binder
    {
        readonly SendBgService service;

        public SendBgServiceBinder(SendBgService service)
        {
            this.service = service;
        }

        public SendBgService GetSendBgService()
        {
            return service;
        }
    }
}
