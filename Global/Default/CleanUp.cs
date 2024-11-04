namespace TukarFaktur.Global.Default
{
    using System;
    using System.Runtime.InteropServices;

    public static class CleanUp
    {
        public static void CleanUpGCCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void CleanUpObject(object obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
        }
    }
}

