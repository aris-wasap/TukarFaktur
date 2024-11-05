namespace TukarFaktur.Global.Customize
{
    using SAPbobsCOM;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using TukarFaktur;
    using TukarFaktur.Global.Default;

    internal class CreateLayout
    {
        public static void AddLayout(string MenuId, string TypeName, string AddOnName, string AddOnFormType, string LayoutName, string RptFileName)
        {
            if (GetServices.GetCreateLayout(AddOnName) != "N")
            {
                ReportType dataInterface;
                int num;
                ReportTypesService businessService = (ReportTypesService) Program.oCompany.GetCompanyService().GetBusinessService(ServiceTypes.ReportTypesService);
                string typeCode = GetServices.GetTypeCode(MenuId);
                if (string.IsNullOrEmpty(typeCode))
                {
                    dataInterface = (ReportType) businessService.GetDataInterface(ReportTypesServiceDataInterfaces.rtsReportType);
                    dataInterface.TypeName = TypeName;
                    dataInterface.AddonName = AddOnName;
                    dataInterface.AddonFormType = AddOnFormType;
                    dataInterface.MenuID = MenuId;
                    typeCode = businessService.AddReportType(dataInterface).TypeCode;
                }
                int.TryParse(GetServices.GetCountDocCode(typeCode, LayoutName), out num);
                if (num == 0)
                {
                    ReportLayoutsService service2 = (ReportLayoutsService) Program.oCompany.GetCompanyService().GetBusinessService(ServiceTypes.ReportLayoutsService);
                    ReportLayout pIReportLayout = (ReportLayout) service2.GetDataInterface(ReportLayoutsServiceDataInterfaces.rlsdiReportLayout);
                    pIReportLayout.Author = Program.oCompany.UserName;
                    pIReportLayout.Category = ReportLayoutCategoryEnum.rlcCrystal;
                    pIReportLayout.Name = LayoutName;
                    pIReportLayout.TypeCode = typeCode;
                    ReportLayoutParams params2 = service2.AddReportLayout(pIReportLayout);
                    ReportTypeParams reportTypeParams = GetReportTypeParams(typeCode);
                    dataInterface = businessService.GetReportType(reportTypeParams);
                    dataInterface.DefaultReportLayout = params2.LayoutCode;
                    businessService.UpdateReportType(dataInterface);
                    BlobParams pIBlobParams = (BlobParams) Program.oCompany.GetCompanyService().GetDataInterface(CompanyServiceDataInterfaces.csdiBlobParams);
                    pIBlobParams.Table = "RDOC";
                    pIBlobParams.Field = "Template";
                    BlobTableKeySegment segment = pIBlobParams.BlobTableKeySegments.Add();
                    segment.Name = "DocCode";
                    segment.Value = params2.LayoutCode;
                    using (FileStream stream = new FileStream(Application.StartupPath + @"\" + RptFileName, FileMode.Open))
                    {
                        int length = (int) stream.Length;
                        byte[] buffer = new byte[length];
                        stream.Read(buffer, 0, length);
                        Blob pIBlob = (Blob) Program.oCompany.GetCompanyService().GetDataInterface(CompanyServiceDataInterfaces.csdiBlob);
                        pIBlob.Content = Convert.ToBase64String(buffer, 0, length);
                        Program.oCompany.GetCompanyService().SetBlob(pIBlobParams, pIBlob);
                    }
                }
            }
        }

        public static ReportTypeParams GetReportTypeParams(string reportTypeCode)
        {
            ReportTypesService businessService = (ReportTypesService) Program.oCompany.GetCompanyService().GetBusinessService(ServiceTypes.ReportTypesService);
            ReportTypesParams reportTypeList = businessService.GetReportTypeList();
            for (int i = 0; i < reportTypeList.Count; i++)
            {
                if (reportTypeList.Item(i).TypeCode == reportTypeCode)
                {
                    return reportTypeList.Item(i);
                }
            }
            return null;
        }
    }
}

