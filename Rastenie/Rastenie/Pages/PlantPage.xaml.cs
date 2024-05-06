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
using VariablePartLibrary.Services;
using VariablePartLibrary.Models;

namespace Rastenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlantPage.xaml
    /// </summary>
    public partial class PlantPage : Page
    {
        Plant contextPlant;
        public PlantPage(Plant plant)
        {
            InitializeComponent();
            if (plant.PlantTypeId == 1)
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(100, 50, 78));
            if (plant.PlantTypeId == 2)
                MainGrid.Background = Brushes.LightPink;
            if (plant.PlantTypeId == 3)
                MainGrid.Background = Brushes.LightBlue;
            contextPlant = plant;
            DataContext = contextPlant;
        }
        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
