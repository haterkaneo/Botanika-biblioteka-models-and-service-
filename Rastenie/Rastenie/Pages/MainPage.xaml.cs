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
using VariablePartLibrary.Models;
using VariablePartLibrary.Services;

namespace Rastenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            CBTypes.ItemsSource = DBService.Instance.GetModelData<PlantType>().ToList();
            DGPlants.ItemsSource = DBService.Instance.GetModelData<Plant>().ToList();
        }
        private void DGPlants_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedPlant = DGPlants.SelectedItem as Plant;
            if (selectedPlant == null)
                return;
            NavigationService.Navigate(new PlantPage(selectedPlant));
        }

        private void BFilter_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            var searchText = TBSearch.Text.ToLower();

            var plants = DBService.Instance.GetModelData<Plant>().ToList();

            if (string.IsNullOrWhiteSpace(searchText) == false)
            {
                plants = plants.Where(x => x.Name.ToLower().Contains(searchText)).ToList();
                
            }

            var selectedType = CBTypes.SelectedItem as PlantType;
            if (selectedType != null)
                plants = plants.Where(x => x.PlantTypeId == selectedType.Id).ToList();
            DGPlants.ItemsSource = plants.ToList();
        }
    }
}
