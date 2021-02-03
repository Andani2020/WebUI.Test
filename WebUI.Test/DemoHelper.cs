using System;
using System.Threading;

namespace WebUI.Test
{
    internal static class DemoHelper
    { 
     public static void Pause(int secondsToPause = 3000)
    {
        Thread.Sleep(secondsToPause);
    }

    }
}
