﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Football_Players_Base
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Player> playersList; //do wczytywania z pliku
        private List<int> ageList;

        public MainWindow()
        {
            InitializeComponent();

            ageList = new List<int>();

            for (int i = 15; i <=55; i++)
            {
                ageList.Add(i);
            }
            age.ItemsSource = ageList;
            age.SelectedValue = 25;

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (forenameTextBox.Text.ToString().Trim() != "" && surnameTextBox.Text.ToString().Trim() != "")
            {
                Player player = new Player(forenameTextBox.Text.ToString(), surnameTextBox.Text.ToString(), Int32.Parse(age.Text), Double.Parse(weight_number.Text.ToString().Replace(".",",")));
                listBox.Items.Add(player);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Remove(listBox.SelectedItem);
        }


        private void listBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player selectedValue = listBox.SelectedItem as Player;
            if (selectedValue != null)
            {
                forenameTextBox.Text = selectedValue.Forename;
                surnameTextBox.Text = selectedValue.surname;
                age.Text = selectedValue.age.ToString();
                weight.Value = selectedValue.weight;
            }
            else
            {
                forenameTextBox.Text = "";
            }
        }
    }
}
