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
            
            var fernando = new Person
            {
                Id = 1,
                Name = "Fernando"
            };

            var russ = new Person
            {
                Id = 2,
                Name = "Russ"
            };

            var nick = new Person
            {
                Id = 3,
                Name = "Nick"
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

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstLeft))
            {
                return;
            }
            var selectedPerson = lstLeft.SelectedItem as Person;

            RemoveFromListBox(lstLeft, selectedPerson);

            AddToListBox(lstRight, selectedPerson);
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            if (NothingSelectedIn(lstRight))
            {
                return;
            }
            var selectedPerson = lstRight.SelectedItem as Person;

            RemoveFromListBox(lstRight, selectedPerson);

            AddToListBox(lstLeft, selectedPerson);
        }

        private void RemoveFromListBox(ListBox listBox, Person selectedPerson)
        {
            listBox.Items.Remove(selectedPerson);
        }

        private void AddToListBox(ListBox listBox, Person selectedPerson)
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

            var apple = new Food
            {
                Id = 1,
                Name = "Apple"
            };

            var tomato = new Food
            {
                Id = 2,
                Name = "Tomato"
            };

            var kiwi = new Food
            {
                Id = 3,
                Name = "Kiwi"
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

    }
}
