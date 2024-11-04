namespace TukarFaktur.Global.Customize
{
    using SAPbobsCOM;
    using SAPbouiCOM;
    using System;
    using TukarFaktur;
    using TukarFaktur.Global.Default;

    internal class FormatedSearch
    {
        public static void QueryGenerator(string QueryCategory, string QuerySelect, string QueryDescription, string FormID, string ItemID, string ColumnID, bool refresh, string refreshField)
        {
            try
            {
                string str = GetServices.RecordsetExecuteQuery("SELECT \"CategoryId\" FROM OQCN Where \"CatName\" = '" + QueryCategory + "'");
                if (string.IsNullOrEmpty(str))
                {
                    QueryCategories businessObject = (QueryCategories) Program.oCompany.GetBusinessObject(BoObjectTypes.oQueryCategories);
                    businessObject.Name = QueryCategory;
                    businessObject.Permissions = "YYYYYYYYYYYYYYY";
                    businessObject.Add();
                    char[] separator = new char[] { '\t' };
                    str = Program.oCompany.GetNewObjectKey().Split(separator)[0];
                    CleanUp.CleanUpObject(businessObject);
                    CleanUp.CleanUpGCCollect();
                }
                string[] textArray1 = new string[] { "select \"IntrnalKey\" from OUQR Where \"QName\" = '", QueryDescription, "' and \"QCategory\" = '", str, "'" };
                if (string.IsNullOrEmpty(GetServices.RecordsetExecuteQuery(string.Concat(textArray1))))
                {
                    int num;
                    int.TryParse(str, out num);
                    UserQueries queries = (UserQueries) Program.oCompany.GetBusinessObject(BoObjectTypes.oUserQueries);
                    queries.Query = QuerySelect;
                    queries.QueryCategory = num;
                    queries.QueryDescription = QueryDescription;
                    queries.Add();
                    char[] chArray2 = new char[] { '\t' };
                    string str2 = Program.oCompany.GetNewObjectKey().Split(chArray2)[0];
                    CleanUp.CleanUpObject(queries);
                    CleanUp.CleanUpGCCollect();
                }
            }
            catch (Exception exception)
            {
                Program.oApplication.SetStatusBarMessage(exception.Message, BoMessageTime.bmt_Short, true);
            }
        }
    }
}

