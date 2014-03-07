using System;
using System.Collections;
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

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstLeft))
            {
                return;
            }
            var selectedItem = lstLeft.SelectedItem as IDBDisplayable;

            RemoveFromListBox(lstLeft, selectedItem);

            var lstRightItemCount = lstRight.Items.Count;
            selectedItem.SortOrder = lstRightItemCount + 1;

            AddToListBox(lstRight, selectedItem);
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedItem = lstRight.SelectedItem as IDBDisplayable;

            RemoveFromListBox(lstRight, selectedItem);

            selectedItem.SortOrder = 0;

            AddToListBox(lstLeft, selectedItem);
        }

        private void RemoveFromListBox(ListBox listBox, IDBDisplayable selectedItem)
        {
            listBox.Items.Remove(selectedItem);
        }

        private void AddToListBox(ListBox listBox, IDBDisplayable selectedItem)
        {
            listBox.Items.Add(selectedItem);
        }

        private void AddToListBoxAt(ListBox listBox, IDBDisplayable selectedItem, int index)
        {
            listBox.Items.Insert(index, selectedItem);
        }

        private bool NothingSelectedIn(ListBox listBoxToCheck)
        {
            return listBoxToCheck.SelectedIndex < 0;
        }



















        private void btnUp_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedItem = lstRight.SelectedItem as IDBDisplayable;
            var selectedItemIndex = lstRight.SelectedIndex;

            if (selectedItemIndex == 0)
            {
                return;
            }

            var aboveItemIndex = selectedItemIndex - 1;
            var aboveItem = (IDBDisplayable) lstRight.Items[aboveItemIndex];

            selectedItem.SortOrder = aboveItemIndex + 1;
            aboveItem.SortOrder = selectedItemIndex + 1;

            RefreshRightListBox();
        }

        private ArrayList listBoxItemsToArrayList(ListBox lstBox)
        {
            var items = new ArrayList(lstBox.Items.Count);

            foreach (var item in lstBox.Items)
            {
                items.Add(item);
            }

            return items;
        }

        private void RefreshRightListBox()
        {
            var items = listBoxItemsToArrayList(lstRight);

            items.Sort();

            lstRight.Items.Clear();

            foreach (var item in items)
            {
                lstRight.Items.Add(item);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedItem = lstRight.SelectedItem as IDBDisplayable;
            var selectedItemIndex = lstRight.SelectedIndex;

            if (selectedItemIndex == (lstRight.Items.Count - 1))
            {
                return;
            }

            var belowItemIndex = selectedItemIndex + 1;
            var belowItem = (IDBDisplayable) lstRight.Items[belowItemIndex];

            selectedItem.SortOrder = belowItemIndex + 1;
            belowItem.SortOrder = selectedItemIndex + 1;

            RefreshRightListBox();
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
