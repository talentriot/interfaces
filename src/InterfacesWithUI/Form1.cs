using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            var apple = new Food
            {
                Id = 1,
                Name = "Apple",
                Calories = 45
            };

            var tomato = new Food
            {
                Id = 2,
                Name = "Tomato",
                Calories = 30
            };

            var kiwi = new Food
            {
                Id = 3,
                Name = "Kiwi",
                Calories = 1000
            };

            var foods = new List<Food>
            {
                apple,
                tomato,
                kiwi
            };

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


















        private void InitializeListBoxesWithFoods()
        {
            lstLeft.Items.Clear();

            var fernando = new Person
            {
                Id = 1,
                FirstName = "Fernando",
                LastName = "Cardenas"
            };

            var russ = new Person
            {
                Id = 2,
                FirstName = "Russ"
            };

            var nick = new Person
            {
                Id = 3,
                FirstName = "Nick"
            };

            var people = new List<Person>
            {
                fernando,
                russ,
                nick
            };

            foreach (var person in people)
            {
                lstLeft.Items.Add(person);
            }
        }

    }
}
