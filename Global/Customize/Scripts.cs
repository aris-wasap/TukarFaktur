namespace TukarFaktur.Global.Customize
{
    using SAPbobsCOM;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using TukarFaktur;
    using TukarFaktur.Global.Default;

    public class Scripts
    {
        public static void CreateSP(Mode.QueryMode queryMod, string queryObj)
        {
            try
            {
                string ssql = SetQuery(queryMod, Program.DatabaseName, queryObj);
                if (!string.IsNullOrEmpty(GetServices.RecordsetExecuteQuery(ssql)))
                {
                    DelQuery(queryMod, queryObj);
                }
                using (StreamReader reader = new StreamReader(GetPath(queryObj)))
                {
                    ssql = reader.ReadToEnd();
                }
                GetServices.RecordsetExecuteQuery(ssql);
            }
            catch (Exception exception)
            {
                throw new Exception(queryObj + " | " + exception.Message);
            }
        }

        public static void DelQuery(Mode.QueryMode queryMod, string queryObj)
        {
            Mode.SAPDB sAPDBType = GetSAPDBType(Program.boDataServerTypes);
            switch (queryMod)
            {
                case Mode.QueryMode.qProcedures:
                    switch (sAPDBType)
                    {
                        case Mode.SAPDB.SQLSERVER:
                            GetServices.ExecuteQuery("DROP PROCEDURE [dbo].[" + queryObj + "]");
                            return;

                        case Mode.SAPDB.HANA:
                            GetServices.ExecuteQuery("DROP PROCEDURE \"" + queryObj + "\"");
                            return;
                    }
                    break;

                case Mode.QueryMode.qFunctions:
                    switch (sAPDBType)
                    {
                        case Mode.SAPDB.SQLSERVER:
                            GetServices.ExecuteQuery("DROP FUNCTION [dbo].[" + queryObj + "]");
                            return;

                        case Mode.SAPDB.HANA:
                            GetServices.ExecuteQuery("DROP FUNCTION \"" + queryObj + "\"");
                            return;
                    }
                    break;

                case Mode.QueryMode.qViews:
                    switch (sAPDBType)
                    {
                        case Mode.SAPDB.SQLSERVER:
                            GetServices.ExecuteQuery("DROP VIEW [dbo].[" + queryObj + "]");
                            return;

                        case Mode.SAPDB.HANA:
                            GetServices.ExecuteQuery("DROP VIEW \"" + queryObj + "\"");
                            return;
                    }
                    break;
            }
        }

        public static string GetPath(string sqlPath)
        {
            Mode.SAPDB sAPDBType = GetSAPDBType(Program.boDataServerTypes);
            string str = string.Empty;
            switch (sAPDBType)
            {
                case Mode.SAPDB.SQLSERVER:
                    str = "SQL/";
                    break;

                case Mode.SAPDB.HANA:
                    str = "HANA/";
                    break;
            }
            string[] textArray1 = new string[] { Application.StartupPath, "/SP/", str, sqlPath, ".sql" };
            return string.Concat(textArray1);
        }

        private static Mode.SAPDB GetSAPDBType(BoDataServerTypes dbType)
        {
            if (dbType.ToString().Contains("MSSQL"))
            {
                return Mode.SAPDB.SQLSERVER;
            }
            if (dbType != BoDataServerTypes.dst_HANADB)
            {
                throw new NotSupportedException($"Database type {dbType} is not supported.");
            }
            return Mode.SAPDB.HANA;
        }

        public static string SetQuery(Mode.QueryMode queryMod, string connString, string queryObj)
        {
            Mode.SAPDB sAPDBType = GetSAPDBType(Program.boDataServerTypes);
            switch (queryMod)
            {
                case Mode.QueryMode.qProcedures:
                    switch (sAPDBType)
                    {
                        case Mode.SAPDB.SQLSERVER:
                            return ("SELECT t0.name FROM sys.objects t0 WHERE object_id = OBJECT_ID(N'[dbo].[" + queryObj + "]') AND type in (N'P', N'PC')");

                        case Mode.SAPDB.HANA:
                        {
                            string[] textArray1 = new string[] { "SELECT \"PROCEDURE_NAME\" FROM \"SYS\".\"PROCEDURES\" WHERE \"SCHEMA_NAME\" = '", connString, "' AND \"PROCEDURE_NAME\" = '", queryObj, "'" };
                            return string.Concat(textArray1);
                        }
                    }
                    break;

                case Mode.QueryMode.qFunctions:
                    switch (sAPDBType)
                    {
                        case Mode.SAPDB.SQLSERVER:
                            return ("SELECT t0.name FROM sys.objects t0 WHERE object_id = OBJECT_ID(N'[dbo].[" + queryObj + "]') AND type in (N'F', N'FN', N'TF')");

                        case Mode.SAPDB.HANA:
                        {
                            string[] textArray2 = new string[] { "SELECT \"FUNCTION_NAME\" FROM \"SYS\".\"FUNCTIONS\" WHERE \"SCHEMA_NAME\" = '", connString, "' AND \"FUNCTION_NAME\" = '", queryObj, "'" };
                            return string.Concat(textArray2);
                        }
                    }
                    break;

                case Mode.QueryMode.qViews:
                    switch (sAPDBType)
                    {
                        case Mode.SAPDB.SQLSERVER:
                            return ("SELECT t0.name FROM sys.objects t0 WHERE object_id = OBJECT_ID(N'[dbo].[" + queryObj + "]') AND type in (N'V', N'PC')");

                        case Mode.SAPDB.HANA:
                        {
                            string[] textArray3 = new string[] { "SELECT T0.\"VIEW_NAME\" FROM SYS.VIEWS T0 WHERE T0.\"VIEW_NAME\" = '", queryObj, "' AND T0.\"SCHEMA_NAME\" = '", connString, "'" };
                            return string.Concat(textArray3);
                        }
                    }
                    break;
            }
            return string.Empty;
        }
    }
}

