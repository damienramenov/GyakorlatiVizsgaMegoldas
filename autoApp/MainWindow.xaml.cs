using DataAccess.Service;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

namespace autoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AutoService _service = new();
        public MainWindow()
        {
            InitializeComponent();

            LoadComboBoxItems();

            LoadFlottaItems();
        }

        private void LoadComboBoxItems()
        {
            markaComboBox.ItemsSource = _service.GetMarkas().ToList();
            tipusComboBox.ItemsSource = _service.GetTipuses().ToList();
            szinComboBox.ItemsSource = _service.GetSzins().ToList();
        }

        private void LoadFlottaItems()
        {
            flottaDataGrid.ItemsSource = _service.GetFlottas();
        }
    }
}