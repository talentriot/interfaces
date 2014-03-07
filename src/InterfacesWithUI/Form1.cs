using System;
using System.Linq;
using System.Collections.Generic;
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

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstLeft))
            {
                return;
            }
            var selectedFood = lstLeft.SelectedItem as IDBDisplayable;

            RemoveFromListBox(lstLeft, selectedFood);

            AddToListBox(lstRight, selectedFood);
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

        private void AddToListBox(ListBox listBox, IDBDisplayable selectedPerson)
        {
            listBox.Items.Add(selectedPerson);
            AddToListBoxInOrder(listBox);
        }

        private bool NothingSelectedIn(ListBox listBoxToCheck)
        {
            return listBoxToCheck.SelectedIndex < 0;
        }

        private void AddToListBoxInOrder(ListBox listBox)
        {
            // take each item which is in the list, put it into an arraylist
            // call sort on the array list
            // clear the listbox
            // add each item form the array list to the listbox
            var itemArray = new List<ISortable>();
            foreach (var item in listBox.Items.Cast<ISortable>())
            {
                itemArray.Add((ISortable)item);
            }
            itemArray = itemArray.OrderBy(item => item.SortOrder).ToList();

            listBox.Items.Clear();
            foreach (var item in itemArray)
            {
                listBox.Items.Add(item); 
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedPerson = lstRight.SelectedItem as ISortable;
            var selectedPersonIndex = lstRight.SelectedIndex;

            if (selectedPersonIndex > 0)
            {
                selectedPerson.SortOrder--;
                var personAbove = lstRight.Items[selectedPersonIndex - 1] as ISortable;
                personAbove.SortOrder++;
            }

            AddToListBoxInOrder(lstRight);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedPerson = lstRight.SelectedItem as ISortable;
            var selectedPersonIndex = lstRight.SelectedIndex;

            if (lstRight.Items.Count - 1 > selectedPersonIndex)
            {
                selectedPerson.SortOrder++;
                var personBelow = lstRight.Items[selectedPersonIndex + 1] as ISortable;
                personBelow.SortOrder--;
            }

            AddToListBoxInOrder(lstRight);
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
