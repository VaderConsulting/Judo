using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace Haidenban
{
    public partial class frmRoutine : Form
    {
        #region Constants

        private const string ENGLISHTITLE = "Routine";
        private const string KANJITITLE = "ルーチン (Rūchin)";

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

        private System.Timers.Timer _TitleTimer = new System.Timers.Timer(5000);
        private bool _FormTextIsJapanese = false;
        
        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmRoutine()
        {
            InitializeComponent();

            _TitleTimer.Elapsed += _TitleTimer_Elapsed;

            _TitleTimer.Start();
        }

        private void _TitleTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _TitleTimer.Stop();

            if (_FormTextIsJapanese)
            {
                this.OnUIThread(() => Text = KANJITITLE);
            }
            else
            {
                this.OnUIThread(() => Text = ENGLISHTITLE);
            }

            _FormTextIsJapanese = !_FormTextIsJapanese;

            _TitleTimer.Start();
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion
    }
}
