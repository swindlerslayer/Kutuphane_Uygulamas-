using DevExpress.XtraSplashScreen;

using Kutuphane_Uygulaması.Wait;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Uygulaması.Data.Wait
{
    public class Loading
    {
        public static SplashScreenManager sp = new SplashScreenManager(typeof(WaitForm1), new SplashFormProperties(null, true, true));
 

        public static void Open()
        {
            if (sp.IsSplashFormVisible)
            {

                sp.CloseWaitForm();
                
            }
            sp.ShowWaitForm();
        }

        public static void Close()
        {
            if (sp.IsSplashFormVisible)
            {
                sp.CloseWaitForm();
            }

        }
    }
}
