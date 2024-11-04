namespace TukarFaktur.Services.Realisasi
{
    using SAPbobsCOM;
    using System;
    using TukarFaktur;
    using TukarFaktur.Global.Default;

    public class Realisasi
    {
        public static string GetBranchByDocNum(string DocNum)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"U_Branch\" FROM \"@ODPO\" T0 INNER JOIN \"NNM1\" T1 ON T1.\"Series\" = T0.\"Series\" WHERE T1.\"SeriesName\" ||'-'|| T0.\"DocNum\" ='" + DocNum + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static string GetCollectorByDocNum(string DocNum)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"U_Collector\" FROM \"@ODPO\" T0 INNER JOIN \"NNM1\" T1 ON T1.\"Series\" = T0.\"Series\" WHERE T1.\"SeriesName\" ||'-'|| T0.\"DocNum\" ='" + DocNum + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static string GetDayByDocNum(string DocNum)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"U_Day\" FROM \"@ODPO\" T0 INNER JOIN \"NNM1\" T1 ON T1.\"Series\" = T0.\"Series\" WHERE T1.\"SeriesName\" ||'-'|| T0.\"DocNum\" ='" + DocNum + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static string GetDpoIdByDocNum(string DocNum)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"DocEntry\" FROM \"@ODPO\" T0 INNER JOIN \"NNM1\" T1 ON T1.\"Series\" = T0.\"Series\" WHERE T1.\"SeriesName\" ||'-'|| T0.\"DocNum\" ='" + DocNum + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static Recordset GetDpoList(string area, string docnum)
        {
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            string[] textArray1 = new string[] { Program.MethodProcedure, " \"__TukarFaktur_GetDaftarPenagihanOutlet\" ('", area, "', '", docnum, "')" };
            return GetServices.RecordsetGetData(string.Concat(textArray1));
        }

        public static Recordset GetRayon()
        {
            string ssql = "";
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            ssql = "SELECT T0.\"U_Rayon\" FROM \"@ODPO\" T0 WHERE T0.\"Status\" ='O'";
            return GetServices.RecordsetGetData(ssql);
        }

        public static Recordset GetRealisasiList(int docEntry, string objType)
        {
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            return GetServices.RecordsetGetData($"{Program.MethodProcedure} \"__TukarFaktur_GetRealisasi\" ({docEntry}, '{objType}')");
        }

        public static string GetRemarksByDocNum(string DocNum)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"U_Remarks\" FROM \"@ODPO\" T0 INNER JOIN \"NNM1\" T1 ON T1.\"Series\" = T0.\"Series\" WHERE T1.\"SeriesName\" ||'-'|| T0.\"DocNum\" ='" + DocNum + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }
    }
}

