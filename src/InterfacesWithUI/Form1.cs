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
        private List<IDBDisplayable> _reorderableItems = new List<IDBDisplayable>(); 
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
            _reorderableItems.Clear();

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
            var selectedFood = lstLeft.SelectedItem as IDBDisplayable;

            RemoveFromListBox(lstLeft, selectedFood);

            AddToListBox(lstRight, selectedFood);
            AddToReorderableList(selectedFood);
        }

        private void AddToReorderableList(IDBDisplayable selectedItem)
        {
            selectedItem.Index = lstRight.Items.Count - 1;
            _reorderableItems.Add(selectedItem);
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
            RemoveFromReorderableList(selectedFood);
        }

        private void RemoveFromReorderableList(IDBDisplayable selectedItem)
        {
            var removedIndex = selectedItem.Index;
            _reorderableItems.Where(item => item.Index > removedIndex).ToList().ForEach(item => item.Index--);
            _reorderableItems.Remove(selectedItem);
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
            _reorderableItems.Clear();

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
            var selectedItemIndex = lstRight.SelectedIndex;
            ReorderListBox(selectedItemIndex, -1);
        }

        private void ReorderListBox(int selectedItemIndex, int indexIncValue)
        {
            if (ItemCannotBeMoved(selectedItemIndex, indexIncValue))
            {
                return;
            }
            var selectedItem = _reorderableItems.Find(item => item.Index == selectedItemIndex);
            var itemToSwapWith = _reorderableItems.Find(item => item.Index == selectedItemIndex + indexIncValue);
            selectedItem.Index += indexIncValue;
            itemToSwapWith.Index -= indexIncValue;
            _reorderableItems = _reorderableItems.OrderBy(item => item.Index).ToList();
            lstRight.Items.Clear();
            _reorderableItems.ForEach(item => lstRight.Items.Add(item));
            lstRight.SelectedIndex = selectedItemIndex + indexIncValue;
        }

        private bool ItemCannotBeMoved(int selectedItemIndex, int indexIncValue)
        {
            var nextIndex = selectedItemIndex + indexIncValue;
            return nextIndex < 0 || nextIndex > lstRight.Items.Count - 1;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedPersonIndex = lstRight.SelectedIndex;
            ReorderListBox(selectedPersonIndex, 1);
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
