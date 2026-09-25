using Classes;
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
using static Utilities.Extensions;

namespace GUITest
{
    public partial class frmMain : Form
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

        Tournament _Tournament = null;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void frmMain_Load(object sender, EventArgs e)
        {
            Initialise();

            //string DataPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Data");

            // Testing
            //DataPath = @"C:\Users\YourUser\OneDrive\VS Projects\Shisutemu\Data";

            //string DatabaseFilename = System.IO.Path.Combine(DataPath, "Shisutemu.mdf");

            //string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DatabaseFilename + ";Integrated Security=True;Connect Timeout=30";

            //Belts BeltList = new Belts();
            //BeltList.ConnectionString = ConnectionString;

            //BeltList.Load();


        }

        private void Serial_DataReceived(object sender, DataTransferEventArgs e)
        {
            Console.WriteLine(e.StringData);
        }

        private void btnLoadPeople_Click(object sender, EventArgs e)
        {
            Initialise();

            LoadPeople();
        }

        private void btnShowMats_Click(object sender, EventArgs e)
        {
            ShowMats();
        }

        private void lstMats_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListboxItem SelectedItem = (ListboxItem)lstMats.SelectedItems[0];
                Mat SelectedMat = (Mat)SelectedItem.Tag;

                if (SelectedItem != null)
                {
                    frmMat MatForm = new frmMat(SelectedMat, _Tournament.WeightCategories);

                    MatForm.Show();
                }

            }
        }

        private void lvwPeople_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvwPeople.SelectedItems.Count > 0)
                {
                    Person p = (Person)lvwPeople.SelectedItems[0].Tag;

                    frmPerson PersonForm = new frmPerson(p, _Tournament.WeightCategories);

                    PersonForm.Show();
                }
            }
        }

        private void lvwWeightCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvwWeightCategories.SelectedItems.Count > 0)
                {
                    WeightCategory Category = (WeightCategory)lvwWeightCategories.SelectedItems[0].Tag;

                    //frmWeightCategory WeightCategoryForm = new frmWeightCategory(Category, _Tournament.WeightCategories);

                    //WeightCategoryForm.Show();

                    frmWeightCategoryPicker WeightCategoryForm = new frmWeightCategoryPicker(Category, _Tournament.WeightCategories);

                    WeightCategoryForm.Show();
                }

                //frmWeightCategoryPicker CategoryPickerForm = new frmWeightCategoryPicker(null, _Tournament.WeightCategories);

                //CategoryPickerForm.Show();
            }


        }

        private void lvwAgeCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvwAgeCategories.SelectedItems.Count > 0)
                {
                    AgeCategory Category = (AgeCategory)lvwAgeCategories.SelectedItems[0].Tag;

                    frmAgeCategory AgeCategoryForm = new frmAgeCategory(Category, _Tournament.WeightCategories);

                    AgeCategoryForm.Show();
                }
            }
        }

        #endregion

        #region Private Methods

        private void Initialise()
        {
            this.Show();
            this.Refresh();

            _Tournament = new Tournament(new DateTime(2017, 01, 01), new DateTime(2017, 01, 02), "Rockingham");

            lvwAgeCategories.Items.Clear();
            lvwWeightCategories.Items.Clear();
            lvwPeople.Items.Clear();
            lstMats.Items.Clear();

            _Tournament.SetMatCount(2);
            _Tournament.LoadCategories(@"C:\Users\YourUser\Documents\Visual Studio 2017\Projects\Shisutemu\Data\Categories.xml");
            //_Tournament.LoadCategories(@"C:\Users\YourUser\Documents\Visual Studio 2017\Projects\Shisutemu\Data\Female Categories.xml");

            ShowMats();

            LoadPeople();

            _Tournament.DistributeWeightCategoriesAmongstMats(true);

            lvwAgeCategories.BeginUpdate();

            foreach (AgeCategory a in _Tournament.AgeCategories)
            {
                if (a.Members.Count > 0)
                {
                    ListViewItem Item = new ListViewItem(a.Name);
                    Item.Tag = a;

                    if (a.Members.Count == 1)
                    {
                        Item.BackColor = Color.OrangeRed;
                    }
                    else if (a.Members.Count == 2)
                    {
                        Item.BackColor = Color.LightPink;
                    }
                    else
                    {
                        Item.BackColor = Color.LightGreen;
                    }

                    lvwAgeCategories.Items.Add(Item);
                }
            }

            lvwAgeCategories.EndUpdate();

            lvwWeightCategories.BeginUpdate();

            // Order the weight categories


            foreach (WeightCategory w in _Tournament.WeightCategories)
            {
                if (w.Members.Count > 0)
                {
                    ListViewItem Item = new ListViewItem(w.Name);

                    Item.Tag = w;

                    if (w.Members.Count == 1)
                    {
                        Item.BackColor = Color.OrangeRed;
                    }
                    else if (w.Members.Count == 2)
                    {
                        Item.BackColor = Color.LightPink;
                    }
                    else
                    {
                        Item.BackColor = Color.LightGreen;
                    }

                    lvwWeightCategories.Items.Add(Item);
                }
            }

            lvwWeightCategories.EndUpdate();

            lvwPeople.BeginUpdate();

            foreach (Person p in _Tournament.Players)
            {
                ListViewItem Item = new ListViewItem(p.Name.ToString());

                if (p.Player.Rank.Value < 12)
                {
                    Item.ImageIndex = p.Player.Rank.Value;
                }
                else
                {
                    Item.ImageIndex = 11;
                }


                Item.Tag = p;

                if (p.Player.Flag)
                {
                    Item.BackColor = Color.OrangeRed;
                }
                else
                {
                    Item.BackColor = Color.LightGreen;
                }

                if (p.Player.AgeCategory == null || p.Player.PrimaryWeightCategory == null)
                {
                    Item.BackColor = Color.LightGray;
                }

                lvwPeople.Items.Add(Item);
            }

            lvwPeople.EndUpdate();
        }

        private void ShowMats()
        {
            int Index = 0;

            lstMats.Items.Clear();

            foreach (Mat Mat in _Tournament.Mats)
            {
                Index++;
                ListboxItem Item = new ListboxItem("A Random Name", Mat);

                lstMats.Items.Add(Item);
            }
        }

        private void LoadPeople()
        {
            //_Tournament.LoadEntrantsFromFile(@"C:\Users\YourUser\OneDrive\VS Projects\Shisutemu\Data\2016_Entrants.csv");
            //_Tournament.LoadEntrantsFromFile(@"C:\Users\YourUser\Documents\Visual Studio 2017\Projects\Shisutemu\Data\EntrantExport2017SouthWestJudoChampionships_2710_104550.csv");
        }



        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
