using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classes
{
    public partial class frmWeightCategory : Form
    {
        private WeightCategory _Category = null;
        ObservableCollection<WeightCategory> _Categories = null;

        public frmWeightCategory(WeightCategory Category, ObservableCollection<WeightCategory> Categories)
        {
            InitializeComponent();

            _Category = Category;
            _Categories = Categories;
        }

        private void frmWeightCategory_Load(object sender, EventArgs e)
        {
            if (_Category != null)
            {
                txtName.Text = _Category.Name;

                if (_Category.Members != null)
                {
                    foreach (Person Member in _Category.Members)
                    {
                        ListViewItem Item = new ListViewItem(Member.Name.FullName());
                        Item.Tag = Member;

                        if (Member.Player.Flag)
                        {
                            Item.BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            Item.BackColor = Color.LightGreen;
                        }
                        
                        lvwMembers.Items.Add(Item);
                    }
                }
            }
        }

        private void lvwMembers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvwMembers.SelectedItems.Count > 0)
                {
                    Person p = (Person)lvwMembers.SelectedItems[0].Tag;

                    frmPerson PersonForm = new frmPerson(p, _Categories);

                    PersonForm.Show();
                }
            }
        }
    }
}
