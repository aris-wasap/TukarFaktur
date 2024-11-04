using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Xml;

namespace TukarFaktur
{
    [FormAttribute("TukarFaktur.FormPenagihanOutlet", "FormPenagihanOutlet.b1f")]
    class FormPenagihanOutlet : UserFormBase
    {
        public FormPenagihanOutlet()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("tab1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("txtId").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("mtx1").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("txtDocNum").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_16").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_18").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_19").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_21").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_22").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_23").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_24").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_25").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.ComboBox ComboBox3;
        private SAPbouiCOM.Button Button1;
    }
}