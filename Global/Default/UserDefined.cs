namespace TukarFaktur.Global.Default
{
    using SAPbobsCOM;
    using SAPbouiCOM;
    using System;
    using System.Runtime.InteropServices;
    using TukarFaktur;

    internal static class UserDefined
    {
        private static int lErrCode;
        private static int lRetCode;
        private static string sErrMsg;

        public static void AddUDO(string ParentTables, string ChildTables, string UdoCode, string UdoName, BoUDOObjType boUDOObjType)
        {
            if (GetServices.GetUserDefinedObject(UdoCode, ParentTables))
            {
                UserObjectsMD businessObject = null;
                businessObject = (UserObjectsMD) Program.oCompany.GetBusinessObject(BoObjectTypes.oUserObjectsMD);
                businessObject.Code = UdoCode;
                businessObject.Name = UdoName;
                businessObject.ObjectType = boUDOObjType;
                businessObject.TableName = ParentTables;
                if (ChildTables != "")
                {
                    businessObject.ChildTables.TableName = ChildTables;
                }
                if (boUDOObjType == BoUDOObjType.boud_Document)
                {
                    businessObject.ManageSeries = BoYesNoEnum.tYES;
                    businessObject.CanCancel = BoYesNoEnum.tYES;
                    businessObject.CanClose = BoYesNoEnum.tYES;
                    businessObject.CanDelete = BoYesNoEnum.tNO;
                    businessObject.CanFind = BoYesNoEnum.tYES;
                    businessObject.CanYearTransfer = BoYesNoEnum.tNO;
                    businessObject.CanLog = BoYesNoEnum.tYES;
                    businessObject.LogTableName = "A" + ParentTables;
                    businessObject.CanCreateDefaultForm = BoYesNoEnum.tNO;
                    businessObject.ApplyAuthorization = BoYesNoEnum.tYES;
                    businessObject.FindColumns.ColumnAlias = "DocEntry";
                    businessObject.FindColumns.Add();
                    businessObject.FindColumns.ColumnAlias = "DocNum";
                    businessObject.FindColumns.Add();
                }
                if (boUDOObjType == BoUDOObjType.boud_MasterData)
                {
                    businessObject.ManageSeries = BoYesNoEnum.tNO;
                    businessObject.CanCancel = BoYesNoEnum.tNO;
                    businessObject.CanClose = BoYesNoEnum.tNO;
                    businessObject.CanDelete = BoYesNoEnum.tYES;
                    businessObject.CanFind = BoYesNoEnum.tYES;
                    businessObject.CanYearTransfer = BoYesNoEnum.tNO;
                    businessObject.CanLog = BoYesNoEnum.tYES;
                    businessObject.LogTableName = "A" + ParentTables;
                    businessObject.CanCreateDefaultForm = BoYesNoEnum.tNO;
                    businessObject.ApplyAuthorization = BoYesNoEnum.tYES;
                    businessObject.FindColumns.ColumnAlias = "Code";
                    businessObject.FindColumns.Add();
                    businessObject.FindColumns.ColumnAlias = "Name";
                    businessObject.FindColumns.Add();
                }
                lRetCode = businessObject.Add();
                if (lRetCode > 0)
                {
                    Program.oCompany.GetLastError(out lRetCode, out sErrMsg);
                    if (lRetCode == -1)
                    {
                    }
                }
                else
                {
                    Program.oApplication.StatusBar.SetText("UDO: " + businessObject.Name + " was added successfully", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                }
                businessObject = null;
                GC.Collect();
            }
        }

        public static object AddUserFields(UserFieldsMD oUserFieldsMD, string UdtName, string FieldName, string FieldDescription, BoFieldTypes boFieldTypes, BoFldSubTypes boFldSubTypes = 0, int Size = 0, string[] validValues = null, string LinkedTables = null)
        {
            if (!GetServices.GetUserDefinedField(UdtName, FieldName))
            {
                goto Label_025E;
            }
            oUserFieldsMD = null;
            oUserFieldsMD = (UserFieldsMD) Program.oCompany.GetBusinessObject(BoObjectTypes.oUserFields);
            oUserFieldsMD.TableName = UdtName;
            oUserFieldsMD.Name = FieldName;
            oUserFieldsMD.Description = FieldDescription;
            oUserFieldsMD.Type = boFieldTypes;
            if (string.IsNullOrEmpty(LinkedTables))
            {
                oUserFieldsMD.LinkedTable = LinkedTables;
            }
            if (validValues != null)
            {
                for (int i = 0; i < validValues.Length; i++)
                {
                    if ((validValues[i] == "Yes") || (validValues[i] == "No"))
                    {
                        string str = validValues[i].Substring(0, 1);
                        oUserFieldsMD.ValidValues.SetCurrentLine(i);
                        oUserFieldsMD.ValidValues.Value = str;
                        oUserFieldsMD.ValidValues.Description = validValues[i];
                        oUserFieldsMD.ValidValues.Add();
                    }
                    else
                    {
                        oUserFieldsMD.ValidValues.SetCurrentLine(i);
                        oUserFieldsMD.ValidValues.Value = validValues[i];
                        oUserFieldsMD.ValidValues.Description = validValues[i];
                        oUserFieldsMD.ValidValues.Add();
                    }
                }
            }
            switch (boFieldTypes)
            {
                case BoFieldTypes.db_Alpha:
                    switch (boFldSubTypes)
                    {
                        case BoFldSubTypes.st_None:
                            oUserFieldsMD.SubType = boFldSubTypes;
                            oUserFieldsMD.EditSize = Size;
                            goto Label_01C5;

                        case BoFldSubTypes.st_Checkbox:
                            oUserFieldsMD.SubType = boFldSubTypes;
                            oUserFieldsMD.DefaultValue = "N";
                            goto Label_01C5;
                    }
                    break;

                case BoFieldTypes.db_Numeric:
                    oUserFieldsMD.EditSize = Size;
                    break;

                case BoFieldTypes.db_Float:
                    oUserFieldsMD.SubType = boFldSubTypes;
                    break;
            }
        Label_01C5:
            lRetCode = oUserFieldsMD.Add();
            if (lRetCode > 0)
            {
                Program.oCompany.GetLastError(out lRetCode, out sErrMsg);
                if (lRetCode == -1)
                {
                }
            }
            else
            {
                string[] textArray1 = new string[] { "Field: '", oUserFieldsMD.Name, "' was added successfuly to ", oUserFieldsMD.TableName, " Table" };
                Program.oApplication.StatusBar.SetText(string.Concat(textArray1), BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
            }
            oUserFieldsMD = null;
            GC.Collect();
        Label_025E:
            return null;
        }

        public static void AddUserTable(UserTablesMD oUserTablesMD, string Name, string Description, BoUTBTableType Type)
        {
            oUserTablesMD = null;
            oUserTablesMD = (UserTablesMD) Program.oCompany.GetBusinessObject(BoObjectTypes.oUserTables);
            UserTablesMD businessObject = (UserTablesMD) Program.oCompany.GetBusinessObject(BoObjectTypes.oUserTables);
            bool byKey = businessObject.GetByKey(Name);
            CleanUp.CleanUpObject(businessObject);
            CleanUp.CleanUpGCCollect();
            if (!byKey)
            {
                oUserTablesMD.TableName = Name;
                oUserTablesMD.TableDescription = Description;
                oUserTablesMD.TableType = Type;
                lRetCode = oUserTablesMD.Add();
                if (lRetCode > 0)
                {
                    if (lRetCode == -1)
                    {
                    }
                }
                else
                {
                    Program.oApplication.StatusBar.SetText("Table: " + oUserTablesMD.TableName + " was added successfully", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                }
                oUserTablesMD = null;
                GC.Collect();
            }
        }
    }
}

