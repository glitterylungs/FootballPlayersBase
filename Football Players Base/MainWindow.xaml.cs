using System;
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
using System.Text.Json;
using System.IO;



namespace Football_Players_Base

{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileName = "C:/Users/ja/source/repos/Football Players Base/Football Players Base/footballPlayersData.json";
        private List<int> ageList;

        public MainWindow()
        {
            TextBoxWithErrorProvider.BrushForAll = Brushes.Red;

            InitializeComponent();

            string jsonString = File.ReadAllText(fileName);
            List<Player> playersList = JsonSerializer.Deserialize<List<Player>>(jsonString);
            foreach(Player player in playersList)
            {
                listBox.Items.Add(player);
            }

                ageList = new List<int>();

                for (int i = 15; i <= 55; i++) // uzupełnienie comboboxa wartościami
                {
                    ageList.Add(i);
                }
                age.ItemsSource = ageList;
                age.SelectedValue = 25;

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            List<Player> playersList = new List<Player>();

            foreach (Player player in listBox.Items)
            {
                playersList.Add(player);
            }
            var jsonString = JsonSerializer.Serialize(playersList);
            File.WriteAllText(fileName, jsonString);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isNoEmpty(forenameTextBox) & isNoEmpty(surnameTextBox)) 
                {
                    Player player = new Player(forenameTextBox.Text.ToString(), surnameTextBox.Text.ToString(), Int32.Parse(age.Text), Double.Parse(weight_number.Text.ToString().Replace(".", ",")));
                    
                    listBox.Items.Add(player);

                    listBox.SelectedItem = null;

                    forenameTextBox.Text = ""; //wyczyszczenie pol po dodaniu wartości do listbox
                    surnameTextBox.Text = "";
                    age.SelectedValue = 25;
                    weight.Value = 55;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void listBoxSelectionChanged(object sender, SelectionChangedEventArgs e) //po wybraniu wartosci w listbox wpisanie jej do pól
        {
            try
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
                    surnameTextBox.Text = "";
                    age.SelectedValue = 25;
                    weight.Value = 55;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Player selectedValue = listBox.SelectedItem as Player;
                if (selectedValue != null)
                {
                    selectedValue.Forename = forenameTextBox.Text;
                    selectedValue.surname = surnameTextBox.Text;
                    selectedValue.age = Int32.Parse(age.Text);
                    selectedValue.weight = weight.Value;
                    if (isNoEmpty(forenameTextBox) & isNoEmpty(surnameTextBox))
                    {
                        listBox.Items.Refresh();

                        listBox.SelectedItem = null;

                        forenameTextBox.Text = "";
                        surnameTextBox.Text = "";
                        age.SelectedValue = 25;
                        weight.Value = 55;
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isNoEmpty(TextBoxWithErrorProvider tb)
        {
            if (tb.Text.Trim() == "")
            {
                tb.SetError("Fill in the field");
                return false;
            }
            tb.SetError("");
            return true;
        }

    }
}
