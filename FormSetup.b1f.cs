using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TukarFaktur
{
    [FormAttribute("TukarFaktur.FormSetup", "FormSetup.b1f")]
    class FormSetup : UserFormBase
    {
        public FormSetup()
        {
            SAPbouiCOM.Framework.Application.SBO_Application.Menus.Item("1289").Activate();
            this.Matrix0.AutoResizeColumns();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("txtCode").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_3").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("mtx").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.EditText EditText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Matrix Matrix0;
    }
}
