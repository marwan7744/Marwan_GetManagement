using DevExpress.CodeParser.Diagnostics;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DMM.AddPages;
using DMM.Page;
using MANGEMENT.BL;
using MANGEMENT.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMM
{
    public partial class MAIN : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        // نخزن الصفحة في متغير عام
        private Page_Home page_Home;
        product_DO_Entities2 db;
        TB_SUPLIERS tbAdd;
        int id;
        MANGEMENT.BL.CLS_LOGIN log = new MANGEMENT.BL.CLS_LOGIN();

        internal void ShowSupplier()
        {
            MessageBox.Show("عرض سجل ديون الموردين");
        }

        public MAIN()
        {
            InitializeComponent();
            LoadHomePage();

          //  btn_home_Click(new object, new EventArgs());
        }

        //الصفخة الرئسية


        //private void LoadPage(DevExpress.XtraEditors.XtraUserControl Page)
        //{
        //    try
        //    {
        //        pn_Container.Controls.Clear(); // تنضيف
        //        Page.Dock = DockStyle.Fill; 
        //        pn_Container.Controls.Add(Page);
        //    }
        //    catch{
        //        return;
        //    }
        //}
        private void LoadPage(UserControl Page)
        {
            panelControl1.Controls.Clear();   //pn_Container
            Page.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(Page);
        }

        private void LoadHomePage()
        {
            Page_Home page = new Page_Home();
            LoadPage(page);
        }
        public static class Session
        {
            public static string UserRole = "";   // مثلاً: "مدير" أو "عامل"
            public static string UserName = "";   // اسم المستخدم
            public static int UserID = 0;         // المعرف إذا أردت استخدامه
        }
        private void btn_Home_Click(object sender, EventArgs e)
        {
            // حسب نوع المستخدم نطبّق الصلاحيات
            if (Session.UserRole == "مدير")
            {
                page_Home.Show();
                page_Home.BringToFront();
            }
            else if (Session.UserRole == "عامل")
            {
                // تعطيل الصلاحيات حسب العامل
               // main.btn_Report.Enabled = false;
                //page_Home.btn_User.Enabled = false;
                page_Home.العملاءToolStripMenuItem.Enabled = false;
                page_Home.المنتوجاتToolStripMenuItem.Enabled = false;
                page_Home.المخازنToolStripMenuItem.Enabled = false;
                page_Home.إدارةالاصنافToolStripMenuItem.Enabled = false;
                page_Home.علميةالمخزونToolStripMenuItem.Enabled = false;
                page_Home.إدارةالمبيعاتToolStripMenuItem.Enabled = false;
                page_Home.التعديلToolStripMenuItem.Enabled = false;
                page_Home.إدارةالعملاءToolStripMenuItem1.Enabled = false;
                page_Home.كشفالحسابToolStripMenuItem.Enabled = false;
                page_Home.إدارةالموردينToolStripMenuItem.Enabled = false;
                page_Home.كشفحسابالموردينToolStripMenuItem.Enabled = false;
                page_Home.إدارةمستندالدفعToolStripMenuItem1.Enabled = false;
                page_Home.إدارةمستندالقبضToolStripMenuItem1.Enabled = false;
                page_Home.إدارToolStripMenuItem.Enabled = false;
                page_Home.الفواتيرToolStripMenuItem.Enabled = false;
                page_Home.الصندوقToolStripMenuItem.Enabled = false;

                page_Home.Show();
                page_Home.BringToFront();
            }
        }

        //Page_Home page = new Page_Home();
        //page.العملاءToolStripMenuItem.Enabled = false;
        //page.المنتوجاتToolStripMenuItem.Enabled = false;
        //page.المخازنToolStripMenuItem.Enabled = false;
        //page.إدارةالاصنافToolStripMenuItem.Enabled = false;
        //page.علميةالمخزونToolStripMenuItem.Enabled = false;
        //page.إدارةالمبيعاتToolStripMenuItem.Enabled = false;
        //page.التعديلToolStripMenuItem.Enabled = false;
        //page.إدارةالعملاءToolStripMenuItem1.Enabled = false;
        //page.كشفالحسابToolStripMenuItem.Enabled = false;
        //page.إدارةالموردينToolStripMenuItem.Enabled = false;
        //page.كشفحسابالموردينToolStripMenuItem.Enabled = false;
        //page.إدارةمستندالدفعToolStripMenuItem1.Enabled = false;
        //page.إدارةمستندالقبضToolStripMenuItem1.Enabled = false;
        //page.إدارToolStripMenuItem.Enabled = false;
        //page.الفواتيرToolStripMenuItem.Enabled = false;
        //page.الصندوقToolStripMenuItem.Enabled = false;
        //LoadPage(page);




        private void btn_Logout_ItemClick(object sender, ItemClickEventArgs e)
        {

            Close();
        }


        private void btn_Suppliers_Click(object sender, EventArgs e)
        {
            try
            {
                RevenueForm FRM = new RevenueForm();
                FRM.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void MAIN_Activated(object sender, EventArgs e)  //التحديث
        {
            BL.UPDATE uPDATE = new BL.UPDATE();
          await Task.Run(()=> uPDATE.SupplierDataUpdate());

          await Task.Run(() => uPDATE.CustomerDataUpdate());
        }

        private void btn_Customer_Click(object sender, EventArgs e)
        {
         
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_Analysis_Click(object sender, EventArgs e)
        {
            FRM_INV_SUPP frm = new FRM_INV_SUPP();
            frm.ShowDialog();
        }

        private void btn_User_Click(object sender, EventArgs e)
        {
            //Page_Users page = new Page_Users();
            //LoadPage(page);
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();


        }

        private void txt_Role_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            //FRM_Settings frm_settings = new FRM_Settings();
            //frm_settings.Show();
        }

        private void pn_Container_Click(object sender, EventArgs e)
        {

        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Page_Customer Page = new Page_Customer();
            LoadPage(Page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Page_Customer Page = new Page_Customer();
            LoadPage(Page);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_Settings frm_settings = new FRM_Settings();
            frm_settings.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FRM_Settings frm_settings = new FRM_Settings();
            frm_settings.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {
                //اما في عمليات الاختيار او انه فارغ 

                db = new product_DO_Entities2();
                tbAdd = db.TB_SUPLIERS.Where(X => X.ID == id).FirstOrDefault();
                DMM.AddPages.Log_Supplier Add = new DMM.AddPages.Log_Supplier();
                Add.txt_id.Text = id.ToString();
                Add.txt_Name.Text =tbAdd.FullName.ToString();
                Add.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FRM_CONFIG frm = new FRM_CONFIG();
            frm.ShowDialog();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            FRM_DAILY_EXPENSES frm = new FRM_DAILY_EXPENSES();
            frm.ShowDialog();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            FRM_USER_LIST FRM = new FRM_USER_LIST();
            FRM.ShowDialog();
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            FRM_CONFIG frm = new FRM_CONFIG();
            frm.ShowDialog();
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            FRM_BACKUP frm = new FRM_BACKUP();
            frm.ShowDialog();
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            FRM_RESTOR frm = new FRM_RESTOR();
            frm.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
