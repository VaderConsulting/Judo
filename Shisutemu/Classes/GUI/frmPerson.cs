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
    public partial class frmPerson : Form
    {
        Person _Person = null;
        ObservableCollection<WeightCategory> _Categories = null;

        public frmPerson(Person Person, ObservableCollection<WeightCategory> Categories)
        {
            InitializeComponent();
            //this.Text = Person.KanjiTypeName + " (" + Person.JapaneseTypeName + ")";
            //lblName.Text = Person.EnglishTypeName + ": " + Person.ObjectName;

            _Person = Person;
            _Categories = Categories;
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            txtAge.Text = _Person.Player.Age.ToString();
            txtWeight.Text = _Person.Player.Weight.ToString();
			txtClub.Text = _Person.Player.Club.Name;

            if (_Person.Player.AgeCategory != null)
            {
                txtAgeCategory.Text = _Person.Player.AgeCategory.Name;
            }

            if (_Person.Player.PrimaryWeightCategory != null)
            {
                txtWeightCategory.Text = _Person.Player.PrimaryWeightCategory.Name;
            }

            foreach (string Comment in _Person.Player.SystemComments)
            {
                lstSystemComments.Items.Add(Comment);
            }

            chkFlagged.Checked = _Person.Player.Flag;
        }

        private void btnBrowseWeightCategories_Click(object sender, EventArgs e)
        {
            frmWeightCategoryPicker CategoryPickerForm = new frmWeightCategoryPicker(_Person, _Categories);

            CategoryPickerForm.Show();
        }
    }
}
