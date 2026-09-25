using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using System.Collections.ObjectModel;

namespace Classes
{
    public partial class frmMat : Form
    {
        Mat _Mat = null;
        ObservableCollection<WeightCategory> _Categories = null;

        public frmMat(Mat Mat, ObservableCollection<WeightCategory> Categories)
        {
            InitializeComponent();

            _Mat = Mat;
            _Categories = Categories;
        }

        private void frmMat_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void lvwWeightCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvwWeightCategories.SelectedItems.Count > 0)
                {
                    WeightCategory Category = (WeightCategory)lvwWeightCategories.SelectedItems[0].Tag;

                    frmWeightCategory WeightCategoryForm = new frmWeightCategory(Category, _Categories);

                    WeightCategoryForm.Show();
                }
            }
        }

        private void ShowCategories()
        {
            lvwWeightCategories.Items.Clear();

            if (_Mat != null)
            {
                //txtName.Text = _Mat.ObjectName;

                if (_Mat.WeightCategories != null)
                {
                    foreach (WeightCategory Category in _Mat.WeightCategories)
                    {
                        //if (Category.Members.Count > 0)
                            //{
                            ListViewItem Item = new ListViewItem(Category.Name);
                            Item.Tag = Category;

                            if (Category.Members.Count == 0)
                            {
                                Item.BackColor = Color.LightGray;
                            }
                            else if (Category.Members.Count == 1)
                            {
                                Item.BackColor = Color.OrangeRed;
                            }
                            else if (Category.Members.Count == 2)
                            {
                                Item.BackColor = Color.LightPink;
                            }
                            else
                            {
                                Item.BackColor = Color.LightGreen;
                            }

                            lvwWeightCategories.Items.Add(Item);
                        //}
                    }
                }
            }
        }

        private void chkShowPopulatedOnly_CheckedChanged(object sender, EventArgs e)
        {
            ShowCategories();
        }
    }
}
