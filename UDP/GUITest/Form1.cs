using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            White.PlayerScore = new Judo.Score(0, 0, 2, false);
            White.PlayerNation = new Judo.Nation("BEL");
            White.PlayerName = new Judo.Name("Michel", "Casse");
            White.MatchInfo = "";
            White.PlayerRank = 0;

            Blue.PlayerScore = new Judo.Score(0, 0, 1, false);
            Blue.PlayerNation = new Judo.Nation("NED");
            Blue.PlayerName = new Judo.Name("francois", "De Wit");
            Blue.MatchInfo = "";
            Blue.PlayerRank = 0;
        }
    }
}
