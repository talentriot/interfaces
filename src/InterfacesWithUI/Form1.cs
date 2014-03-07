using System;
using System.Windows.Forms;
using DomainAndServices.Domain;
using DomainAndServices.Services;

namespace InterfacesWithUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListBoxDataBindings();
            InitializeListBoxes();
        }

        private void InitializeListBoxDataBindings()
        {
            lstLeft.DisplayMember = "Name";
            lstLeft.ValueMember = "Id";

            lstRight.DisplayMember = "Name";
            lstRight.ValueMember = "Id";
        }

        private void InitializeListBoxes()
        {

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
            var selectedFood = lstLeft.SelectedItem as Food;

            RemoveFromListBox(lstLeft, selectedFood);

            AddToListBox(lstRight, selectedFood);
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedFood = lstRight.SelectedItem as Food;

            RemoveFromListBox(lstRight, selectedFood);

            AddToListBox(lstLeft, selectedFood);
        }

        private void RemoveFromListBox(ListBox listBox, Food selectedPerson)
        {
            listBox.Items.Remove(selectedPerson);
        }

        private void AddToListBox(ListBox listBox, Food selectedPerson)
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

            var peopleService = new PersonDataService();
            var people = peopleService.GetAllPeople();

            foreach (var person in people)
            {
                lstLeft.Items.Add(person);
            }
        }

    }
}
