using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;

namespace TukarFaktur
{
    public class Program
    {
        public static SAPbobsCOM.BoDataServerTypes boDataServerTypes;
        public static string DatabaseId;
        public static string DatabaseName;
        public static string MethodProcedure;
        public static SAPbouiCOM.Application oApplication;
        public static SAPbobsCOM.Company oCompany;
        public static int UserId;
        public static string UserName;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application oApp = null;
                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    //If you want to use an add-on identifier for the development license, you can specify an add-on identifier string as the second parameter.
                    //oApp = new Application(args[0], "XXXXX");
                    oApp = new Application(args[0]);
                }

                oApplication = SAPbouiCOM.Framework.Application.SBO_Application;
                oCompany = (SAPbobsCOM.Company)oApplication.Company.GetDICompany();
                boDataServerTypes = oCompany.DbServerType;
                UserName = oCompany.UserName;
                UserId = oCompany.UserSignature;
                DatabaseName = oCompany.CompanyDB;
                DatabaseId = oCompany.CompanyID;
                if (boDataServerTypes == SAPbobsCOM.BoDataServerTypes.dst_HANADB)
                {
                    MethodProcedure = "CALL";
                }

                Menu MyMenu = new Menu();
                MyMenu.AddMenuItems();
                oApp.RegisterMenuEventHandler(MyMenu.SBO_Application_MenuEvent);
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent);
                oApp.Run();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        static void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    break;
                default:
                    break;
            }
        }
    }
}
