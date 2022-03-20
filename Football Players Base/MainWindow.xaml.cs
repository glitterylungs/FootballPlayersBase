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

namespace Football_Players_Base
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
