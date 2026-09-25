using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haidenban
{
    public partial class frmAdministration : Form
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private ToolTip ToolTip = new ToolTip();
        private Timer ToolTipTimer = new Timer();
        private bool CanShowToolTip = true;
        private string ToolTipText = "Kanri (Administration)";

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmAdministration()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x2A0: // WM_NCMOUSEHOVER
                    return;
                case (int)0x00A0: // WM_NCMOUSEMOVE
                    if (m.WParam == new IntPtr(0x0002)) // HT_CAPTION
                    {
                        if (CanShowToolTip)
                        {
                            CanShowToolTip = false;
                            ToolTip.Show(ToolTipText, this, this.PointToClient(Cursor.Position), ToolTip.AutoPopDelay);
                            ToolTipTimer.Start();
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        #endregion


    }
}
