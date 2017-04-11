using System;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System.Collections.Generic;

namespace HelloMC01.TizenMobile
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());

            try
            {
                MobileCenter.Start("54aa94d6-753f-40c3-b3f7-5af2767c7a42",
                   typeof(Analytics)
                   //, typeof(Crashes)
                   );
                MobileCenterLog.Assert(MobileCenterLog.LogTag, "SUCCESSFULLY STARTED");
            }
            catch (Exception e)
            {
                MobileCenterLog.Error(MobileCenterLog.LogTag, "EXCEPTION!!!\n" + e.GetType() + '\n' + e.Message);
            }

            try
            {
                Analytics.TrackEvent("Video clicked", 
                    new Dictionary<string, string> { { "Category", "Music" }, { "FileName", "favorite.avi" } });
                MobileCenterLog.Assert(MobileCenterLog.LogTag, "EVENT SENT");
            }
            catch(Exception e)
            {
                MobileCenterLog.Error(MobileCenterLog.LogTag, "EXCEPTION!!!\n" + e.GetType() + '\n' + e.Message);
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            app.Run(args);
        }
    }
}
