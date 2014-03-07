using System;
using System.Collections;
using System.Collections.Generic;
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
            SetSortOrderOnLists();
        }

        private void SetSortOrderOnLists()
        {
            SortService.SetSortOrder(lstLeft.Items.OfType<ISortable>());
            SortService.SetSortOrder(lstRight.Items.OfType<ISortable>());
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstLeft))
            {
                return;
            }
            var selectedFood = lstLeft.SelectedItem as IDBDisplayable;

            RemoveFromListBox(lstLeft, selectedFood);

            AddToListBox(lstRight, selectedFood);

            SetSortOrderOnLists();
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedFood = lstRight.SelectedItem as IDBDisplayable;

            RemoveFromListBox(lstRight, selectedFood);

            AddToListBox(lstLeft, selectedFood);
            SetSortOrderOnLists();
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
            var itemIndex = lstRight.SelectedIndex;
            if (itemIndex == 0)
            {
                return;
            }

            SwapItems(lstRight, itemIndex-1, itemIndex);
            
        }

        private void SwapItems(ListBox listBox, int firstItemIndex, int secondItemIndex)
        {
            var sortableList = lstRight.Items.OfType<ISortable>().ToList();
            var firstItem = sortableList.FirstOrDefault(item => item.SortOrder == (firstItemIndex));
            var secondItem = sortableList.FirstOrDefault(item => item.SortOrder == (secondItemIndex));

            firstItem.SortOrder = secondItemIndex;
            secondItem.SortOrder = firstItemIndex;
            var sortedList = sortableList.OrderBy(item => item.SortOrder).ToList();

            lstRight.Items.Clear();
            sortedList.ForEach(item => lstRight.Items.Add(item));
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var itemIndex = lstRight.SelectedIndex;
            if (itemIndex == lstRight.Items.Count - 1)
            {
                return;
            }

            SwapItems(lstRight, itemIndex, itemIndex + 1);
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
            SetSortOrderOnLists();
        }

    }
}
