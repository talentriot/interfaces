using System;
using System.Linq;
using System.Windows.Forms;
using DomainAndServices.Domain;
using DomainAndServices.Interfaces;
using DomainAndServices.Services;

namespace InterfacesWithUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListBoxDataBindings();
            InitializeListBoxesWithFoods();
        }

        private void InitializeListBoxDataBindings()
        {
            lstLeft.DisplayMember = "Name";
            lstLeft.ValueMember = "Id";

            lstRight.DisplayMember = "Name";
            lstRight.ValueMember = "Id";
        }

        private void InitializeListBoxesWithFoods()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            var foodService = new FoodDataService();
            var foods = foodService.GetAllFoods();

            foreach (var food in foods)
            {
                lstLeft.Items.Add(food);
            }
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstLeft))
            {
                return;
            }
            var selectedItem = lstLeft.SelectedItem as IDBDisplayable;
            RemoveFromListBox(lstLeft, selectedItem);

            AddToListBox(lstRight, selectedItem);
            selectedItem.Index = lstRight.Items.IndexOf(selectedItem);
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedItem = lstRight.SelectedItem as IDBDisplayable;

            RemoveFromListBox(lstRight, selectedItem);

            AddToListBox(lstLeft, selectedItem);
        }

        private void RemoveFromListBox(ListBox listBox, IDBDisplayable selectedPerson)
        {
            listBox.Items.Remove(selectedPerson);
        }

        private void AddToListBox(ListBox listBox, IDBDisplayable selectedPerson)
        {
            listBox.Items.Add(selectedPerson);
        }

        private bool NothingSelectedIn(ListBox listBoxToCheck)
        {
            return listBoxToCheck.SelectedIndex < 0;
        }


        private void InitializeListBoxesWithPeople()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            var peopleService = new PersonDataService();
            var people = peopleService.GetAllPeople();

            foreach (var person in people)
            {
                lstLeft.Items.Add(person);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var listItems = lstRight.Items.OfType<IDBDisplayable>().ToList();
            var selectedPerson = lstRight.SelectedItem as IDBDisplayable;
            if (lstRight.Items.Count == 0 || lstRight.Items.Count == 1 || lstRight.SelectedIndex == 0)
            {
                return;
            }
            lstRight.Items.Clear();
            selectedPerson.Index -= 1;
            listItems.Sort();
            foreach (var item in listItems)
            {
                lstRight.Items.Add(item);
                item.Index = lstRight.Items.IndexOf(item);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var listItems = lstRight.Items.OfType<IDBDisplayable>().ToList();
            var selectedPerson = lstRight.SelectedItem as IDBDisplayable;
            if (lstRight.Items.Count == 0 || lstRight.Items.Count == 1 || lstRight.SelectedIndex == lstRight.Items.Count)
            {
                return;
            }
            lstRight.Items.Clear();
            selectedPerson.Index += 1;
            listItems.Sort();
            foreach (var item in listItems)
            {
                lstRight.Items.Add(item);
                item.Index = lstRight.Items.IndexOf(item);
            }

        }

        private void cmbTypeOfItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indexSelected = cmbTypeOfItems.SelectedIndex;
            if (indexSelected < 0)
            {
                return;
            }
            if (indexSelected == 0)//food
            {
                InitializeListBoxesWithFoods();
            }
            else
            {
                InitializeListBoxesWithPeople();
            }
        }

    }
}
