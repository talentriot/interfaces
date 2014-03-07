using System;
using System.Linq;
using System.Windows.Forms;
using DomainAndServices.Interfaces;
using DomainAndServices.Services;

namespace InterfacesWithUI
{
    public partial class Form1 : Form
    {
        enum MoveDirection
        {
            Up = -1,
            Down = 1, 
        }
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

            var selectedItemAsSortable = selectedItem as ISortable;
            selectedItemAsSortable.SortOrder = lstRight.Items.Count - 1;
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
        }

        private void RemoveFromListBox(ListBox listBox, IDBDisplayable selectedPerson)
        {
            listBox.Items.Remove(selectedPerson);
        }

        private void AddToListBox(ListBox listBox, IDBDisplayable selectedDisplayable)
        {
            listBox.Items.Add(selectedDisplayable);
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
            MoveSelectedItem(MoveDirection.Up);
        }

        private void MoveSelectedItem(MoveDirection direction)
        {
            var orderModifier = (int) direction;

            var selectedItem = lstRight.SelectedItem as ISortable;
            var selectedItemIndex = lstRight.SelectedIndex;

            if (!IsIndexInRightListRange(selectedItem.SortOrder + orderModifier) ||
                !IsIndexInRightListRange(selectedItemIndex + orderModifier)) return;

            var newItemIndex = selectedItemIndex + orderModifier;
            var itemToReplace = lstRight.Items[newItemIndex] as ISortable;
            selectedItem.SortOrder += orderModifier;
            itemToReplace.SortOrder -= orderModifier;

            RepopulateList(newItemIndex);
        }

        private void RepopulateList(int newItemIndex)
        {
            var newListItems = GetSortedList(lstRight);
            lstRight.Items.Clear();
            lstRight.Items.AddRange(newListItems);
            lstRight.SelectedIndex = newItemIndex;
        }

        private bool IsIndexInRightListRange(int index)
        {
            return index >= 0 && index <= lstRight.Items.Count - 1;
        }

        private object[] GetSortedList(ListBox listBox)
        {
            return listBox.Items.Cast<ISortable>().OrderBy(item => item.SortOrder).Cast<object>().ToArray();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            MoveSelectedItem(MoveDirection.Down);
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

        private void lstRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUp.Enabled = lstRight.SelectedIndex > 0;
            btnDown.Enabled = lstRight.SelectedIndex < lstRight.Items.Count - 1;
        }
    }
}
