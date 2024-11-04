namespace TukarFaktur.Global.Default
{
    using System;

    public class Mode
    {
        public enum QueryMode
        {
            qProcedures,
            qFunctions,
            qViews
        }

        public enum SAPDB
        {
            SQLSERVER,
            HANA
        }
    }
}

