using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMM
{
    public partial class FRM_Start : SplashScreen
    {
        product_DO_Entities2 db;
        int state;
        public FRM_Start()
        {
            InitializeComponent();
            //this.labelCopyright.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
        private int ChackStartApp()
        {

            try
            {
               

            }
            catch
            {
                state = 0;
            }
            return state;
        }
    }
}