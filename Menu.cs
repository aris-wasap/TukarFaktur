using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TukarFaktur.Global.Customize;
using TukarFaktur.Services.Setup;

namespace TukarFaktur
{
    class Menu
    {
        public void AddMenuItems()
        {
            SAPbouiCOM.Menus oMenus = null;
            SAPbouiCOM.MenuItem oMenuItem = null;

            oMenus = Application.SBO_Application.Menus;

            if (oMenus.Exists("TukarFaktur"))
            {
                oMenus.RemoveEx("TukarFaktur");
            }
            if (oMenus.Exists("TukarFaktur.FormSetup"))
            {
                oMenus.RemoveEx("TukarFaktur.FormSetup");
            }

            SAPbouiCOM.MenuCreationParams oCreationPackage = null;
            oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
            oMenuItem = Application.SBO_Application.Menus.Item("43520"); // moudles'

            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
            oCreationPackage.UniqueID = "TukarFaktur";
            oCreationPackage.String = "TukarFaktur";
            oCreationPackage.Enabled = true;
            oCreationPackage.Position = -1;

            oMenus = oMenuItem.SubMenus;

            try
            {
                //  If the manu already exists this code will fail
                oMenus.AddEx(oCreationPackage);
            }
            catch (Exception e)
            {

            }

            try
            {
                // Get the menu collection of the newly added pop-up item
                oMenuItem = Application.SBO_Application.Menus.Item("TukarFaktur");
                oMenus = oMenuItem.SubMenus;

                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "TukarFaktur.FormPenagihanOutlet";
                oCreationPackage.String = "Daftar Penagihan Outlet";
                oMenus.AddEx(oCreationPackage);

                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "TukarFaktur.FormRealisasi";
                oCreationPackage.String = "Realisasi Penagihan Outlet";
                oMenus.AddEx(oCreationPackage);

                // Create s sub menu 
                oMenus = Application.SBO_Application.Menus.Item("43523").SubMenus;
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "TukarFaktur.FormSetup";
                oCreationPackage.String = "Add-On Configuration";
                oMenus.AddEx(oCreationPackage);

                //1
                Application.SBO_Application.StatusBar.SetText("1. Create Menu Add-On Configuration successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                //2
                CreateB1Db.CreateDbSetup();
                Application.SBO_Application.StatusBar.SetText("2. Create UDO Add-On Configuration successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                //3
                CreateB1Db.Create();
                Application.SBO_Application.StatusBar.SetText("3. Create UDO Add-On Tukar Faktur successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                //4
                CreateFormatedSearch.Add();
                Application.SBO_Application.StatusBar.SetText("4. Create FMS Add-On Tukar Faktur successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                //5
                CreateLayout.AddLayout("TukarFaktur.FormPenagihanOutlet", "Daftar Penagihan Outlet", "Tukar Faktur", "TukarFaktur.FormPenagihanOutlet", "Layout Penagihan Outlet", "DaftarPenagihanOutlet.rpt");
                CreateLayout.AddLayout("TukarFaktur.FormRealisasi", "Realisasi Penagihan Outlet", "Tukar Faktur", "TukarFaktur.FormRealisasi", "Layout Realisasi", "RealisasiPenagihanOutlet.rpt");
                Application.SBO_Application.StatusBar.SetText("5. Create Layout Add-On Tukar Faktur successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                //6
                CreateScripts.AllScripts();
                Application.SBO_Application.StatusBar.SetText("6. Create Scripts Add-On Tukar Faktur successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                //7
                AddOnConfiguration.CreateCode();
                AddOnConfiguration.CreateCodeDetail();
                Application.SBO_Application.StatusBar.SetText("7. Create List Add-On Configuration successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception er)
            { //  Menu already exists
                //Application.SBO_Application.SetStatusBarMessage("Menu Already Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                Application.SBO_Application.StatusBar.SetText("Menu Already Exists " + er.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
        }

        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form form = null;
            bool flag = false;
            try
            {
                if (pVal.BeforeAction && (pVal.MenuUID == "TukarFaktur.FormPenagihanOutlet"))
                {
                    form = null;
                    flag = false;
                    for (int i = 0; i < Application.SBO_Application.Forms.Count; i++)
                    {
                        form = Application.SBO_Application.Forms.Item(i);
                        if (form.UniqueID == "ODPO_")
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        form.Select();
                    }
                    else
                    {
                        new FormPenagihanOutlet().Show();
                    }
                }
                else if (pVal.BeforeAction && (pVal.MenuUID == "TukarFaktur.FormRealisasi"))
                {
                    form = null;
                    flag = false;
                    for (int j = 0; j < SAPbouiCOM.Framework.Application.SBO_Application.Forms.Count; j++)
                    {
                        form = Application.SBO_Application.Forms.Item(j);
                        if (form.UniqueID == "ORPO_")
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        form.Select();
                    }
                    else
                    {
                        new FormRealisasi().Show();
                    }
                }
                else if (pVal.BeforeAction && (pVal.MenuUID == "TukarFaktur.FormSetup"))
                {
                    form = null;
                    flag = false;
                    for (int k = 0; k < Application.SBO_Application.Forms.Count; k++)
                    {
                        form = Application.SBO_Application.Forms.Item(k);
                        if (form.TypeEx == "TukarFaktur.FormSetup")
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        form.Select();
                    }
                    else
                    {
                        new FormSetup().Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }

    }
}
