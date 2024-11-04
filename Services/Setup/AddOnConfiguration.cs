namespace TukarFaktur.Services.Setup
{
    using SAPbobsCOM;
    using SAPbouiCOM;
    using System;
    using TukarFaktur;
    using TukarFaktur.Global.Default;

    public class AddOnConfiguration
    {
        public static void CreateCode()
        {
            try
            {
                if (string.IsNullOrEmpty(GetCodeAddonConfiguration("B1AddOn")))
                {
                    GeneralService generalService = Program.oCompany.GetCompanyService().GetGeneralService("ADDON");
                    GeneralData dataInterface = (GeneralData) generalService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralData);
                    dataInterface.SetProperty("Code", "B1AddOn");
                    generalService.Add(dataInterface);
                    Program.oApplication.StatusBar.SetText("Data has been saved to UDO successfully.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                }
            }
            catch (Exception exception)
            {
                Program.oApplication.MessageBox("Error: " + exception.Message, 1, "Ok", "", "");
            }
        }

        public static void CreateCodeDetail()
        {
            try
            {
                Recordset addOnInstalled = GetAddOnInstalled();
                if (addOnInstalled.RecordCount > 0)
                {
                    GeneralService generalService = Program.oCompany.GetCompanyService().GetGeneralService("ADDON");
                    GeneralDataParams dataInterface = (GeneralDataParams) generalService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralDataParams);
                    dataInterface.SetProperty("Code", "B1AddOn");
                    GeneralData byParams = generalService.GetByParams(dataInterface);
                    GeneralDataCollection datas = byParams.Child("ADDON1");
                    addOnInstalled.MoveFirst();
                    while (!addOnInstalled.EoF)
                    {
                        string addonCode = addOnInstalled.Fields.Item("AddonCode").Value.ToString();
                        string vtValue = addOnInstalled.Fields.Item("Version").Value.ToString();
                        if (string.IsNullOrEmpty(GetAddonVersionConfigurationDetail("B1AddOn", addonCode)))
                        {
                            GeneralData data2 = datas.Add();
                            data2.SetProperty("U_AddonCode", addonCode);
                            data2.SetProperty("U_Version", vtValue);
                            data2.SetProperty("U_CreateUdo", "Y");
                            data2.SetProperty("U_CreateFms", "Y");
                            data2.SetProperty("U_CreateLayout", "Y");
                            data2.SetProperty("U_CreateSp", "Y");
                        }
                        else
                        {
                            for (int i = 0; i < datas.Count; i++)
                            {
                                GeneralData data3 = datas.Item(i);
                                if (data3.GetProperty("U_AddonCode").ToString() == addonCode)
                                {
                                    data3.SetProperty("U_Version", vtValue);
                                    break;
                                }
                            }
                        }
                        addOnInstalled.MoveNext();
                    }
                    generalService.Update(byParams);
                    Program.oApplication.StatusBar.SetText("Data has been saved to UDO successfully.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                }
            }
            catch (Exception exception)
            {
                Program.oApplication.MessageBox("Error: " + exception.Message, 1, "Ok", "", "");
            }
        }

        public static Recordset GetAddOnInstalled()
        {
            Recordset businessObject = (Recordset) Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            return GetServices.RecordsetGetData("CALL \"__AddOn_Activated\" ('SLDDATA', '" + Program.DatabaseName + "')");
        }

        public static string GetAddonVersionConfigurationDetail(string Code, string AddonCode)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"U_Version\" FROM \"@ADDON1\" T0 WHERE T0.\"Code\" ='" + Code + "' AND T0.\"U_AddonCode\" ='" + AddonCode + "' ");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }

        public static string GetCodeAddonConfiguration(string Code)
        {
            string str2 = "-";
            str2 = GetServices.RecordsetExecuteQuery("SELECT T0.\"Code\" FROM \"@ADDON\" T0 WHERE T0.\"Code\" ='" + Code + "'");
            if (str2 == "")
            {
                return str2;
            }
            return str2;
        }
    }
}

