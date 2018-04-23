using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using System.Reflection;
using DevExpress.XtraBars.Ribbon.Handler;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ribbonControl1.Minimized = true;

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ribbonControl1.SelectedPage = ribbonPage2;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FieldInfo fi = typeof(RibbonControl).GetField("handler", BindingFlags.NonPublic | BindingFlags.Instance);
            Object b = fi.GetValue(ribbonControl1);
            MethodInfo mi = typeof(RibbonHandler).GetMethod("OnPressHeaderPage", BindingFlags.NonPublic | BindingFlags.Instance);
            
            RibbonHitInfo hi = new RibbonHitInfo();
            hi.Page = ribbonPage2;
            mi.Invoke(b, new object[] { hi });

        }

    }
}
