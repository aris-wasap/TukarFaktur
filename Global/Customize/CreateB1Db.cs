namespace TukarFaktur.Global.Customize
{
    using SAPbobsCOM;
    using SAPbouiCOM;
    using System;
    using TukarFaktur;
    using TukarFaktur.Global.Default;

    internal class CreateB1Db
    {
        public static void Create()
        {
            if (GetServices.GetCreateUdo("Tukar Faktur") != "N")
            {
                Tables();
                Fields();
                UserDefinedObject();
            }
        }

        public static void CreateDbSetup()
        {
            TablesSetup();
            FieldsSetup();
            UserDefinedObjectSetup();
        }

        public static void Fields()
        {
            string[] validValues = new string[] { "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu" };
            string[] strArray2 = new string[] { "Yes", "No" };
            UserFieldsMD oUserFieldsMD = null;
            UserDefined.AddUserFields(oUserFieldsMD, "OCRD", "Rayon", "Rayon", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "COLLECTOR", "Department", "Department", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "COLLECTOR", "Branch", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "OINV", "Date_TukarFaktur", "Tanggal Tukar Faktur", BoFieldTypes.db_Date, BoFldSubTypes.st_None, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "OINV", "BaseEntry", "Base Entry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "OINV", "BaseNum", "Base Num", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "OINV", "BaseType", "Base Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ODPO", "Branch", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ODPO", "Rayon", "Rayon", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ODPO", "Collector", "Collector", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ODPO", "CollectorName", "Collector Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ODPO", "Day", "Day", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, validValues, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ODPO", "Remarks", "Remarks", BoFieldTypes.db_Memo, BoFldSubTypes.st_None, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "Selected", "Selected", BoFieldTypes.db_Alpha, BoFldSubTypes.st_Checkbox, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "CardCode", "Customer Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "CardName", "Customer Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "Rayon", "Rayon", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "Address", "Address", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 0xfe, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "DocType", "Document Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "InvType", "Inv Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "SeriesName", "Series", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 10, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "InvNo", "Inv No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "InvEntry", "Inv Entry", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 11, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "InvDate", "Inv Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "DpoType", "Dpo Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "Amount", "Amount Invoice", BoFieldTypes.db_Float, BoFldSubTypes.st_Price, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "BalanceDue", "Balance Due", BoFieldTypes.db_Float, BoFldSubTypes.st_Price, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "PaidAmount", "Paid Amount", BoFieldTypes.db_Float, BoFldSubTypes.st_Price, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "DPO1", "Remarks", "Remarks", BoFieldTypes.db_Memo, BoFldSubTypes.st_None, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "BaseEntry", "Base Entry", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "BaseRef", "DPO No.", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "BaseType", "Base Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "Branch", "Branch", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "Rayon", "Rayon", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "Collector", "Collector", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "CollectorName", "Collector Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 150, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "Day", "Day", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, validValues, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ORPO", "Remarks", "Remarks", BoFieldTypes.db_Memo, BoFldSubTypes.st_None, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "Selected", "Selected", BoFieldTypes.db_Alpha, BoFldSubTypes.st_Checkbox, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "CardCode", "Customer Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 15, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "CardName", "Customer Name", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "Rayon", "Rayon", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 100, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "Address", "Address", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 0xfe, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "DocType", "Document Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "InvType", "Inv Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "SeriesName", "Series", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 10, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "InvNo", "Inv No", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "InvEntry", "Inv Entry", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 11, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "InvDate", "Inv Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "DpoType", "Dpo Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "Amount", "Amount Invoice", BoFieldTypes.db_Float, BoFldSubTypes.st_Price, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "BalanceDue", "Balance Due", BoFieldTypes.db_Float, BoFldSubTypes.st_Price, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "PaidAmount", "Paid Amount", BoFieldTypes.db_Float, BoFldSubTypes.st_Price, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "Remarks", "Remarks", BoFieldTypes.db_Memo, BoFldSubTypes.st_None, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "BaseType", "Base Type", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 20, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "BaseEntry", "Base Entry", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 11, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "RPO1", "BaseLine", "Base Line", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 11, null, null);
            GC.Collect();
        }

        public static void FieldsSetup()
        {
            UserFieldsMD oUserFieldsMD = null;
            UserDefined.AddUserFields(oUserFieldsMD, "ADDON1", "Selected", "Selected", BoFieldTypes.db_Alpha, BoFldSubTypes.st_Checkbox, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ADDON1", "AddonCode", "Addon Code", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ADDON1", "Version", "Version", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 50, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ADDON1", "CreateUdo", "Create UDO", BoFieldTypes.db_Alpha, BoFldSubTypes.st_Checkbox, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ADDON1", "CreateFms", "Create FMS", BoFieldTypes.db_Alpha, BoFldSubTypes.st_Checkbox, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ADDON1", "CreateLayout", "Create Layout", BoFieldTypes.db_Alpha, BoFldSubTypes.st_Checkbox, 0, null, null);
            UserDefined.AddUserFields(oUserFieldsMD, "ADDON1", "CreateSp", "Create Store Procedure", BoFieldTypes.db_Alpha, BoFldSubTypes.st_Checkbox, 0, null, null);
            GC.Collect();
        }

        public static void Tables()
        {
            UserTablesMD oUserTablesMD = null;
            UserDefined.AddUserTable(oUserTablesMD, "COLLECTOR", "Data Collector", BoUTBTableType.bott_NoObject);
            UserDefined.AddUserTable(oUserTablesMD, "RAYON", "Data Rayon", BoUTBTableType.bott_NoObject);
            UserDefined.AddUserTable(oUserTablesMD, "ODPO", "Daftar Penagihan Outlet 1", BoUTBTableType.bott_Document);
            UserDefined.AddUserTable(oUserTablesMD, "DPO1", "Daftar Penagihan Outlet 2", BoUTBTableType.bott_DocumentLines);
            UserDefined.AddUserTable(oUserTablesMD, "ORPO", "Realisasi Penagihan Outlet 1", BoUTBTableType.bott_Document);
            UserDefined.AddUserTable(oUserTablesMD, "RPO1", "Realisasi Penagihan Outlet 2", BoUTBTableType.bott_DocumentLines);
            GC.Collect();
        }

        public static void TablesSetup()
        {
            UserTablesMD oUserTablesMD = null;
            UserDefined.AddUserTable(oUserTablesMD, "ADDON", "Add On Configuration 1", BoUTBTableType.bott_MasterData);
            UserDefined.AddUserTable(oUserTablesMD, "ADDON1", "Add On Configuration 2", BoUTBTableType.bott_MasterDataLines);
            GC.Collect();
        }

        public static void UserDefinedObject()
        {
            UserDefined.AddUDO("ODPO", "DPO1", "ODPO", "Daftar Penagihan Outlet", BoUDOObjType.boud_Document);
            UserDefined.AddUDO("ORPO", "RPO1", "ORPO", "Realisasi Penagihan Outlet", BoUDOObjType.boud_Document);
        }

        public static void UserDefinedObjectSetup()
        {
            UserDefined.AddUDO("ADDON", "ADDON1", "ADDON", "Add On Configuration", BoUDOObjType.boud_MasterData);
        }
    }
}

