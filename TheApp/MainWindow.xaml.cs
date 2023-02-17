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

namespace TheApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Diagnostics.Trace.WriteLine("Starting MainWindow");
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheCore.AddonLoader.LoadAndActivateAllAddons();
                MessageBox.Show(this, "SUCCESS", "Plugin Loading");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Load Addon exception: " + ex.GetType().Name + ", " + ex.ToString());
                MessageBox.Show(this, "ERROR !", "Plugin Loading", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
