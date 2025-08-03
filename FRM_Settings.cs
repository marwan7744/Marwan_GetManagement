using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace DMM
{
    public partial class FRM_Settings : DevExpress.XtraEditors.XtraForm
    {
        MemoryStream ma;
        public FRM_Settings()
        {
             InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        private void SetSettings()   //تقوم بتضمين عملية إرجاع الاعدادات الافتراضية
        {
            var Compname = Properties.Settings.Default.CompanyName;
            var Compdesc = Properties.Settings.Default.CompanyDec;
            txt_name.Text = Compname;
            txt_desc.Text = Compdesc;
            try
            {
                var imgebyt = Convert.FromBase64String(Properties.Settings.Default.Logo);

            }
            catch { 
            }
        }
       private void SaveSettings()   //تقوم باإرسال او حفظ الاعدادات
        {
            Properties.Settings.Default.CompanyName= txt_name.Text;
            Properties.Settings.Default.CompanyDec = txt_desc.Text;
            try
            {
                ma=new MemoryStream();
                pic_logo.Image.Save(ma,System.Drawing.Imaging.ImageFormat.Png);
                Properties.Settings.Default.Logo=Convert.ToBase64String(ma.ToArray());
            }
            catch { 
            
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FRM_Settings_Load(object sender, EventArgs e)
        {
            SetSettings();
        }
    }
}