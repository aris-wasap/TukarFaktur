namespace TukarFaktur.Global.Default
{
    using SAPbobsCOM;
    using System;
    using System.Runtime.InteropServices;
    using TukarFaktur;

    internal class GetServices
    {
        public static void ExecuteQuery(string ssql)
        {
            try
            {
                ((Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset)).DoQuery(ssql);
            }
            catch (Exception exception)
            {
                throw new Exception("ExecuteQuery | " + exception.Message);
            }
        }

        public static string GetCountDocCode(string TypeCode, string LayoutName)
        {
            string[] textArray1 = new string[] { "SELECT COUNT(\"DocCode\") FROM \"RDOC\" T0 WHERE T0.\"TypeCode\" ='", TypeCode, "' and t0.\"DocName\" = '", LayoutName, "'" };
            return RecordsetExecuteQuery(string.Concat(textArray1));
        }

        public static string GetCreateFms(string AddonCode) => 
            RecordsetExecuteQuery("SELECT T0.\"U_CreateFms\" FROM \"@ADDON1\" T0 WHERE T0.\"U_AddonCode\" ='" + AddonCode + "' ");

        public static string GetCreateLayout(string AddonCode) => 
            RecordsetExecuteQuery("SELECT T0.\"U_CreateLayout\" FROM \"@ADDON1\" T0 WHERE T0.\"U_AddonCode\" ='" + AddonCode + "' ");

        public static string GetCreateStoreProcedure(string AddonCode) => 
            RecordsetExecuteQuery("SELECT T0.\"U_CreateSp\" FROM \"@ADDON1\" T0 WHERE T0.\"U_AddonCode\" ='" + AddonCode + "' ");

        public static string GetCreateUdo(string AddonCode) => 
            RecordsetExecuteQuery("SELECT T0.\"U_CreateUdo\" FROM \"@ADDON1\" T0 WHERE T0.\"U_AddonCode\" ='" + AddonCode + "' ");

        public static string GetTypeCode(string MenuId) => 
            RecordsetExecuteQuery("SELECT T0.\"CODE\" FROM \"RTYP\" T0 WHERE T0.\"MNU_ID\" ='" + MenuId + "' ");

        public static bool GetUserDefinedField(string UdtName, string UdfName)
        {
            string[] textArray1 = new string[] { "SELECT T0.\"TableID\" FROM \"CUFD\" T0 WHERE T0.\"TableID\" ='", UdtName, "' AND T0.\"TableID\" ='", UdfName, "' " };
            return (RecordsetExecuteQuery(string.Concat(textArray1)) == "");
        }

        public static bool GetUserDefinedObject(string UdoName, string UdtName) => 
            ((RecordsetExecuteQuery("SELECT T0.\"Code\" FROM \"OUDO\" T0 WHERE T0.\"Code\" ='" + UdoName + "'") == "") && !GetUserDefinedTables(UdtName));

        public static bool GetUserDefinedTables(string UdtName) => 
            (RecordsetExecuteQuery("SELECT T0.\"TableName\" FROM \"OUTB\" T0 WHERE T0.\"TableName\" ='" + UdtName + "'") == "");

        public static string RecordsetExecuteQuery(string ssql)
        {
            string str;
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            businessObject.DoQuery(ssql);
            if (businessObject.EoF)
            {
                str = "";
            }
            else
            {
                str = businessObject.Fields.Item(0).Value.ToString();
            }
            Marshal.ReleaseComObject(businessObject);
            CleanUp.CleanUpObject(businessObject);
            CleanUp.CleanUpGCCollect();
            return str;
        }

        public static Recordset RecordsetGetData(string ssql)
        {
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            businessObject.DoQuery(ssql);
            return businessObject;
        }
    }
}

