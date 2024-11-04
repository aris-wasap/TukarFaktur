namespace TukarFaktur.Services.PenagihanOutlet
{
    using SAPbobsCOM;
    using System;
    using TukarFaktur;
    using TukarFaktur.Global.Default;

    public class PenagihanOutlet
    {
        public static string GetBranch(string Code)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"U_Branch\" FROM \"@RAYON\" T0 WHERE T0.\"Code\" ='" + Code + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static string GetCollectorName(string Code)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"Name\" FROM \"@COLLECTOR\" T0 WHERE T0.\"Code\" ='" + Code + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static Recordset GetCustomerData(string area, int docEntry)
        {
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            return GetServices.RecordsetGetData($"{Program.MethodProcedure} \"__TukarFaktur_GetInvoices\" ('{area}', {docEntry}" );
        }

        public static string GetSeriesName(int Series)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"SeriesName\" FROM \"NNM1\" T0 WHERE T0.\"Series\" =" + Series.ToString());
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static string GetUserBranch(string userName)
        {
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            businessObject.DoQuery("SELECT \"U_Branch\" FROM OUSR WHERE \"USER_CODE\" = '" + userName + "'");
            if (businessObject.RecordCount > 0)
            {
                return businessObject.Fields.Item("U_Branch").Value.ToString();
            }
            return null;
        }
    }
}

