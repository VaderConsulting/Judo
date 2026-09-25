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
    public partial class frmWeightCategoryPicker : Form
    {
        Person _Person = null;
        ObservableCollection<WeightCategory> _Categories = null;
        WeightCategory _SelectedCategory = null;
        ListViewItem _SelectedItem = null;
        Person _SelectedPerson = null;

        public frmWeightCategoryPicker(Person Person, ObservableCollection<WeightCategory> AllCategories)
        {
            InitializeComponent();

            _Person = Person;
            _Categories = new ObservableCollection<WeightCategory>((from WeightCategory in AllCategories
                                                                    where WeightCategory.AgeCategory.ID <= _Person.Player.AgeCategory.WeightLimitID
                                                                       && WeightCategory.AgeCategory.Sex == _Person.Sex
                                                                       && WeightCategory.ID >= _Person.Player.PrimaryWeightCategory.ID
                                                                    orderby WeightCategory.AgeCategory.Order
                                                                    select WeightCategory).ToList());

            Initialise();
        }

        public frmWeightCategoryPicker(WeightCategory Category, ObservableCollection<WeightCategory> AllCategories)
        {
            InitializeComponent();

            _SelectedCategory = Category;

            _Categories = new ObservableCollection<WeightCategory>((from WeightCategory in AllCategories
                                                                    where WeightCategory.AgeCategory.ID <= _SelectedCategory.AgeCategory.WeightLimitID
                                                                       && WeightCategory.AgeCategory.Sex == _SelectedCategory.AgeCategory.Sex
                                                                    orderby WeightCategory.AgeCategory.Order
                                                                    select WeightCategory).ToList());

            Initialise();
        }

        private void Initialise()
        {
            if (_Person != null)
            {
                foreach (WeightCategory w in _Categories)
                {
                    AddGroupToListview(w, lvwCategories);
                }
            }
            else
            {
                foreach (WeightCategory w in _Categories)
                {
                    if (_SelectedCategory.AgeCategory.ID == w.ID)
                    {
                        AddGroupToListview(w, lvwCategories);
                    }
                }
            }

            lvwCategories.SelectedItems.Clear();
        }

        private void AddGroupToListview(WeightCategory Category, ListView Target)
        {
            ListViewGroup ThisGroup = new ListViewGroup(Category.Name);
            ThisGroup.Tag = Category;
            

            // Sort the list by weight, as it is currently sorted by Name
            ObservableCollection<Person> OrderedList = new ObservableCollection<Person>(from p in Category.Members
                                                                                        orderby p.Player.Weight.Kilograms
                                                                                        select p);

            foreach (Person ThisPerson in OrderedList)
            {
                ListViewItem Item = new ListViewItem(ThisPerson.Name.ToString() + " (" + ThisPerson.Player.Weight.Kilograms + " Kg)");
                Item.Tag = ThisPerson;

                if (ThisPerson.Player.Rank.Value < 12)
                {
                    Item.ImageIndex = ThisPerson.Player.Rank.Value;
                }
                else
                {
                    Item.ImageIndex = 11;
                }

                Item.Group = ThisGroup;


                Target.Items.Add(Item);
            }

            Target.Groups.Add(ThisGroup);
        }

        private void lvwCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvwCategories.SelectedItems.Count > 0)
            {
                Person p = (Person)lvwCategories.SelectedItems[0].Tag;

                frmPerson PersonForm = new frmPerson(p, _Categories);

                PersonForm.Show();
            }
        }

        private void frmWeightCategoryPicker_Load(object sender, EventArgs e)
        {
            lvwCategories.SelectedItems.Clear();

            foreach (ListViewItem Item in lvwCategories.Items)
            {
                Person ThisPerson = (Person)Item.Tag;

                if (ThisPerson == _Person)
                {
                    Item.Selected = true;
                    Item.Focused = true;
                }
            }
        }

        private void SelectPerson(ListView TargetListview)
        {
            TargetListview.BeginUpdate();

            if (TargetListview.SelectedItems.Count > 0)
            {
                // Clear all current colours
                if (_SelectedItem != null)
                {
                    _SelectedPerson = (Person)_SelectedItem.Tag;

                    txtPersonName.Text = _SelectedPerson.Name.FullName().ToString();
                    txtAge.Text = _SelectedPerson.Player.Age.ToString();
                    txtWeight.Text = _SelectedPerson.Player.Weight.Kilograms.ToString() + " Kg";
                    txtOver5Percent.Text = "< " + _SelectedPerson.Player.Weight.Minus5Percent.ToString() + " or > " + _SelectedPerson.Player.Weight.Plus5Percent.ToString() + " Kg";
                    txtWithin5Percent.Text = _SelectedPerson.Player.Weight.Minus5Percent.ToString() + " to " + _SelectedPerson.Player.Weight.Plus5Percent.ToString() + " Kg";
                    txtEqual.Text = _SelectedPerson.Player.Weight.Kilograms.ToString() + " Kg";

                    if (_SelectedPerson.Player.Rank != null)
                    {
                        if (_SelectedPerson.Player.Rank.Value < 12)
                        {
                            picBelt.Image = imlBelts.Images[_SelectedPerson.Player.Rank.Value];
                        }
                        else
                        {
                            picBelt.Image = imlBelts.Images[11];
                        }

                    }

                    foreach (ListViewItem Item in TargetListview.Items)
                    {
                        Item.BackColor = SystemColors.Window;
                    }
                }
            }

            lvwCategories.EndUpdate();
        }

        private void ColourListViewItems(Person p, ListView Target)
        {
            foreach (ListViewItem Item in Target.Items)
            {
                Person OtherPerson = (Person)Item.Tag;

                if (p != null)
                {
                    if (p == OtherPerson)
                    {
                        Item.BackColor = SystemColors.HotTrack;
                    }
                    else if (OtherPerson.Player.Weight.Kilograms == p.Player.Weight.Kilograms)
                    {
                        Item.BackColor = Color.LightGreen;
                    }
                    else if (OtherPerson.Player.Weight.Kilograms >= p.Player.Weight.Minus5Percent && OtherPerson.Player.Weight.Kilograms <= p.Player.Weight.Plus5Percent)
                    {
                        Item.BackColor = Color.Orange;
                    }
                    else
                    {
                        Item.BackColor = Color.Red;
                    }
                }
            }
        }

        private void lvwCategories_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _SelectedItem = e.Item;
                SelectPerson(lvwCategories);
                // Colour the items in the current listview according t
                ColourListViewItems(_SelectedPerson, lvwCategories);

                //ColourListViewItems(_SelectedPerson, lvwUpperCategory);

                ShowUpperListview();
            }
        }

        private void lvwUpperCategory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _SelectedItem = e.Item;
                SelectPerson(lvwUpperCategory);
            }
        }

        private void ShowUpperListview()
        {
            lvwUpperCategory.BeginUpdate();
            lvwUpperCategory.Items.Clear();

            //Is there a weight category from an age category above or below the current that we can fit into?
            foreach (WeightCategory w in _Categories)
            {
                if (_SelectedPerson.Player.Weight.Kilograms >= w.LowerWeightLimit && _SelectedPerson.Player.Weight.Kilograms <= w.UpperWeightLimit && _SelectedPerson.Player.PrimaryWeightCategory != w)
                {
                    if (w.ID >= _SelectedPerson.Player.PrimaryWeightCategory.ID)
                    {
                        AddGroupToListview(w, lvwUpperCategory);
                    }
                }
            }

            lvwUpperCategory.EndUpdate();
        }
    }
}
