namespace TukarFaktur.Global.Customize
{
    using System;
    using TukarFaktur.Global.Default;

    internal class CreateFormatedSearch
    {
        private static string QueryCategory = "Tukar Faktur";
        private static string QuerySelect = "";

        public static void Add()
        {
            if (GetServices.GetCreateFms("Tukar Faktur") != "N")
            {
                Collector("Tukar Faktur - Get List Collector", "TukarFaktur.FormPenagihanOutlet", "txtBranch", "-1");
                Rayon("Tukar Faktur - Get List Rayon", "TukarFaktur.FormPenagihanOutlet", "txtSearch", "-1");
                RayonFromDpo("Tukar Faktur - Get List Rayon Dpo", "TukarFaktur.FormRealisasi", "txtRayon", "-1");
                DpoNumber("Tukar Faktur - Get List DPO Number", "TukarFaktur.FormRealisasi", "txtBaseRef", "-1");
            }
        }

        private static void AddOnList(string QueryDescription, string FormID, string ItemID, string ColumnID)
        {
            QuerySelect = "SELECT * FROM \"__AddOnList\"  ";
            FormatedSearch.QueryGenerator(QueryCategory, QuerySelect, QueryDescription, FormID, ItemID, ColumnID, false, "");
            GC.Collect();
        }

        private static void Collector(string QueryDescription, string FormID, string ItemID, string ColumnID)
        {
            QuerySelect = "SELECT * FROM \"@COLLECTOR\"  WHERE \"U_Branch\" = $[$" + ItemID + ".0.0] ORDER BY \"Name\" ASC ";
            FormatedSearch.QueryGenerator(QueryCategory, QuerySelect, QueryDescription, FormID, ItemID, ColumnID, false, "");
            GC.Collect();
        }

        private static void CollectorName(string QueryDescription, string FormID, string ItemID, string ColumnID, string FieldID)
        {
            QuerySelect = "SELECT \"Name\" FROM \"@COLLECTOR\" WHERE \"Code\" = $[$" + ItemID + ".0.0]";
            FormatedSearch.QueryGenerator(QueryCategory, QuerySelect, QueryDescription, FormID, ItemID, ColumnID, false, "");
            GC.Collect();
        }

        private static void DpoNumber(string QueryDescription, string FormID, string ItemID, string ColumnID)
        {
            QuerySelect = "CALL \"__TukarFaktur_GetListDpoNumber\" ($[USER] , NULL) ";
            FormatedSearch.QueryGenerator(QueryCategory, QuerySelect, QueryDescription, FormID, ItemID, ColumnID, false, "");
            GC.Collect();
        }

        private static void Rayon(string QueryDescription, string FormID, string ItemID, string ColumnID)
        {
            QuerySelect = "SELECT \"Code\" FROM \"@RAYON\"  WHERE \"U_Branch\" = ( SELECT \"U_Branch\" FROM OUSR WHERE USERID = $[USER] ) ORDER BY \"Code\" ASC";
            FormatedSearch.QueryGenerator(QueryCategory, QuerySelect, QueryDescription, FormID, ItemID, ColumnID, false, "");
            GC.Collect();
        }

        private static void RayonFromDpo(string QueryDescription, string FormID, string ItemID, string ColumnID)
        {
            QuerySelect = "SELECT T0.\"U_Rayon\" AS \"Rayon\" FROM \"@ODPO\" T0 INNER JOIN \"@DPO1\" T1 ON T1.\"DocEntry\" = T0.\"DocEntry\" AND IFNULL(T1.\"U_Selected\",'') = 'Y' WHERE T0.\"Status\" = 'C' AND T0.\"Canceled\" = 'N' GROUP BY T0.\"U_Rayon\" ORDER BY T0.\"U_Rayon\" ASC ";
            FormatedSearch.QueryGenerator(QueryCategory, QuerySelect, QueryDescription, FormID, ItemID, ColumnID, false, "");
            GC.Collect();
        }
    }
}

