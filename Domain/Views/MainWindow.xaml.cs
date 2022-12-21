using ADO.NET_Task9.DataAccess;
using ADO.NET_Task9.Domain.ViewModels;
using ADO.NET_Task9.Domain.Views;
using ADO.NET_Task9.Entities;
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

namespace ADO.NET_Task9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var homePage = new HomePageUC();
            var homePageViewModel = new HomePageUCViewModel();
            homePage.DataContext = homePageViewModel;
            MyGrid.Children.Add(homePage);
        }
    }
}
