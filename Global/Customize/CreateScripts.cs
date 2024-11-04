﻿namespace TukarFaktur.Global.Customize
{
    using System;
    using TukarFaktur.Global.Default;

    public class CreateScripts
    {
        public static void AllScripts()
        {
            if (GetServices.GetCreateStoreProcedure("Tukar Faktur") != "N")
            {
                Scripts.CreateSP(Mode.QueryMode.qProcedures, "__TukarFaktur_GetDaftarPenagihanOutlet");
                Scripts.CreateSP(Mode.QueryMode.qProcedures, "__TukarFaktur_GetInvoices");
                Scripts.CreateSP(Mode.QueryMode.qProcedures, "__TukarFaktur_GetListDpoNumber");
                Scripts.CreateSP(Mode.QueryMode.qProcedures, "__TukarFaktur_GetRealisasi");
                Scripts.CreateSP(Mode.QueryMode.qProcedures, "__TukarFaktur_LayoutPanagihanOutlet");
                Scripts.CreateSP(Mode.QueryMode.qProcedures, "__TukarFaktur_LayoutRealisasi");
            }
        }
    }
}
