using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Autok
{
    public partial class MainWindow : Window
    {
        private List<Car> cars = new List<Car>();

        public MainWindow()
        {
            InitializeComponent();

            cars = Car.FromFile(@"..\..\..\src\cars.txt");
            DataContext = this;
            List.ItemsSource = cars;

        }

        private void AddToFavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = List.SelectedItem;

            if (selected != null)
            {
                FavoriteList.Items.Add(selected);
            }
        }

        private void DeleteFromFavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = List.SelectedItem;
            if (selected != null && FavoriteList.Items.Contains(selected))
            {
                FavoriteList.Items.Remove(selected);
            }
            else
            {
                MessageBox.Show("This car is not in Favorites!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}