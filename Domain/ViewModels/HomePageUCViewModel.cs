using ADO.NET_Task9.Domain.Command;
using ADO.NET_Task9.Domain.Helpers;
using ADO.NET_Task9.Domain.Views;
using ADO.NET_Task9.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ADO.NET_Task9.Domain.ViewModels
{
    public class HomePageUCViewModel : BaseViewModel
    {
        #region Relay Commands

        public RelayCommand CarDealersCommand { get; set; }
        public RelayCommand ShowCommand { get; set; }

        #endregion

        #region Car Brand
        private ObservableCollection<string> brands;

        public ObservableCollection<string> Brands
        {
            get { return brands; }
            set { brands = value; }
        }

        private string selectedBrand;

        public string SelectedBrand
        {
            get { return selectedBrand; }
            set { selectedBrand = value; SelectedBrandChanged(); }
        }

        private void SelectedBrandChanged()
        {

        }
        #endregion

        #region Car Type
        private ObservableCollection<string> types;

        public ObservableCollection<string> Types
        {
            get { return types; }
            set { types = value; }
        }

        private string selectedType;

        public string SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; SelectedTypeChanged(); }
        }

        private void SelectedTypeChanged()
        {

        }
        #endregion

        #region Car Date Types
        private ObservableCollection<string> dateTypes;

        public ObservableCollection<string> DateTypes
        {
            get { return dateTypes; }
            set { dateTypes = value; }
        }

        private string selectedDateType;

        public string SelectedDateType
        {
            get { return selectedDateType; }
            set { selectedDateType = value; SelectedDateTypeChanged(); }
        }

        private void SelectedDateTypeChanged()
        {

        }
        #endregion

        #region Car Color
        private ObservableCollection<string> colors;

        public ObservableCollection<string> Colors
        {
            get { return colors; }
            set { colors = value; }
        }

        private string selectedColor;

        public string SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; SelectedColorChanged(); }
        }

        private void SelectedColorChanged()
        {

        }
        #endregion

        #region Car Fuel Types
        private ObservableCollection<string> fuelTypes;

        public ObservableCollection<string> FuelTypes
        {
            get { return fuelTypes; }
            set { fuelTypes = value; }
        }

        private string selectedFuelType;

        public string SelectedFuelType
        {
            get { return selectedFuelType; }
            set { selectedFuelType = value; SelectedFuelTypeChanged(); }
        }

        private void SelectedFuelTypeChanged()
        {

        }
        #endregion

        #region Car Minimum Price
        private ObservableCollection<string> minimumPrices;

        public ObservableCollection<string> MinimumPrices
        {
            get { return minimumPrices; }
            set { minimumPrices = value; }
        }

        private string selectedMinimumPrice;

        public string SelectedMinimumPrice
        {
            get { return selectedMinimumPrice; }
            set { selectedMinimumPrice = value; SelectedMinimumPriceChanged(); }
        }

        private void SelectedMinimumPriceChanged()
        {

        }
        #endregion

        #region Car Maximum Price
        private ObservableCollection<string> maximumPrices;

        public ObservableCollection<string> MaximumPrices
        {
            get { return maximumPrices; }
            set { maximumPrices = value; }
        }

        private string selectedMaximumPrice;

        public string SelectedMaximumPrice
        {
            get { return selectedMaximumPrice; }
            set { selectedMaximumPrice = value; SelectedMaximumPriceChanged(); }
        }

        private void SelectedMaximumPriceChanged()
        {

        }
        #endregion

        #region Car Minimum Mileage
        private ObservableCollection<string> minimumMileages;

        public ObservableCollection<string> MinimumMileages
        {
            get { return minimumMileages; }
            set { minimumMileages = value; }
        }

        private string selectedMinimumMileage;

        public string SelectedMinimumMileage
        {
            get { return selectedMinimumMileage; }
            set { selectedMinimumMileage = value; SelectedMinimumMileageChnaged(); }
        }

        private void SelectedMinimumMileageChnaged()
        {

        }
        #endregion

        #region Car Maximum Mileage
        private ObservableCollection<string> maximumMileages;

        public ObservableCollection<string> MaximumMileages
        {
            get { return maximumMileages; }
            set { maximumMileages = value; }
        }

        private string selectedMaximumMileage;

        public string SelectedMaximumMileage
        {
            get { return selectedMaximumMileage; }
            set { selectedMaximumMileage = value; SelectedMaximumMileageChanged(); }
        }

        private void SelectedMaximumMileageChanged()
        {

        }
        #endregion

        #region Car Minimum Year
        private ObservableCollection<string> minimumYears;

        public ObservableCollection<string> MinimumYears
        {
            get { return minimumYears; }
            set { minimumYears = value; }
        }

        private string selectedMinimumYear;

        public string SelectedMinimumYear
        {
            get { return selectedMinimumYear; }
            set { selectedMinimumYear = value; SelectedMinimumYearChanged(); }
        }

        private void SelectedMinimumYearChanged()
        {

        }
        #endregion

        #region Car Maximum Year
        private ObservableCollection<string> maximumYears;

        public ObservableCollection<string> MaximumYears
        {
            get { return maximumYears; }
            set { maximumYears = value; }
        }

        private string selectedMaximumYear;

        public string SelectedMaximumYear
        {
            get { return selectedMaximumYear; }
            set { selectedMaximumYear = value; SelectedMaximumYearChanged(); }
        }

        private void SelectedMaximumYearChanged()
        {

        }
        #endregion

        #region Cars
        private ObservableCollection<UIElement> cars = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }


        #endregion

        public HomePageUCViewModel()
        {
            CarDealersCommand = new RelayCommand((c) =>
            {
                Process.Start("https://turbo.az/avtosalonlar/avtosalon-rh");
            });

            ShowCommand = new RelayCommand((s) =>
            {
                var cars = App.Database.Cars.ToList();

                if (SelectedBrand != Constants.AllBrands)
                    cars = cars.Where(c => c.Brand == SelectedBrand).ToList();

                if (SelectedType != Constants.AllCarTypes)
                    cars = cars.Where(c => c.Type == SelectedType).ToList();

                if (SelectedDateType != Constants.DateTypeAll)
                {
                    if (SelectedDateType == Constants.DateTypeOld)
                        cars = cars.Where(c => c.IsNew == false).ToList();
                    else
                        cars = cars.Where(c => c.IsNew).ToList();
                }

                if (SelectedColor != Constants.AllColors)
                    cars = cars.Where(c => c.Color == SelectedColor).ToList();
                
                if (SelectedFuelType != Constants.AllFuelTypes)
                    cars = cars.Where(c => c.FuelType == SelectedFuelType).ToList();

                if (SelectedMinimumPrice != Constants.NoPrice)
                    cars = cars.Where(c => c.Price >= int.Parse(SelectedMinimumPrice.Replace(Constants.DollarSign,String.Empty).Trim())).ToList();

                if (SelectedMaximumPrice != Constants.NoPrice)
                    cars = cars.Where(c => c.Price <= int.Parse(SelectedMaximumPrice.Replace(Constants.DollarSign, String.Empty).Trim())).ToList();

                if (SelectedMinimumMileage != Constants.NoMileage)
                    cars = cars.Where(c => c.Mileage >= int.Parse(SelectedMinimumMileage.Replace(Constants.Kilometer, String.Empty).Trim())).ToList();

                if (SelectedMaximumMileage != Constants.NoMileage)
                    cars = cars.Where(c => c.Mileage <= int.Parse(SelectedMaximumMileage.Replace(Constants.Kilometer, String.Empty).Trim())).ToList();

                if (SelectedMinimumYear != Constants.NoYear)
                    cars = cars.Where(c => c.Year >= int.Parse(SelectedMinimumYear)).ToList();

                if (SelectedMaximumYear != Constants.NoYear)
                    cars = cars.Where(c => c.Year <= int.Parse(SelectedMaximumYear)).ToList();

                Cars.Clear();
                Thread.Sleep(500);
                foreach (var item in cars)
                {
                    var carUC = new CarUC();
                    var carUCVM = new CarUCViewModel(item);
                    carUC.DataContext = carUCVM;

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(item.ImagePath, UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();
                    carUC.Image.Source = bitmap;

                    Cars.Add(carUC);
                }

                if (Cars.Count == 0)
                {
                    Cars.Add(new NoResultUC());
                }
            });
            // Brands
            Brands = new ObservableCollection<string>(App.Database.Cars.Select(c => c.Brand).Distinct());
            Brands.Insert(Constants.BeginningIndex, Constants.AllBrands);
            SelectedBrand = Brands[Constants.BeginningIndex];

            // Car Types
            Types = new ObservableCollection<string>(App.Database.Cars.Select(c => c.Type).Distinct());
            Types.Insert(Constants.BeginningIndex, Constants.AllCarTypes);
            SelectedType = Types[Constants.BeginningIndex];

            // Car Date Types (Old, New, All)
            DateTypes = new ObservableCollection<string>()
            {
                Constants.DateTypeAll,
                Constants.DateTypeNew,
                Constants.DateTypeOld
            };
            SelectedDateType = DateTypes[Constants.BeginningIndex];

            // Car Exterior Colors
            Colors = new ObservableCollection<string>(App.Database.Cars.Where(car => car.Color != string.Empty).Select(c => c.Color).Distinct());
            Colors.Insert(Constants.BeginningIndex, Constants.AllColors);
            SelectedColor = Colors[Constants.BeginningIndex];

            // Car Fuel Types
            FuelTypes = new ObservableCollection<string>(App.Database.Cars.Select(c => c.FuelType).Distinct());
            FuelTypes.Insert(Constants.BeginningIndex, Constants.AllFuelTypes);
            SelectedFuelType = FuelTypes[Constants.BeginningIndex];

            // All Car Prices
            var prices = App.Database.Cars.Select(c => c.Price.ToString() + Constants.DollarSign).Distinct();

            // Car Minimum Prices
            MinimumPrices = new ObservableCollection<string>(prices);
            MinimumPrices.Insert(Constants.BeginningIndex, Constants.NoPrice);
            SelectedMinimumPrice = MinimumPrices[Constants.BeginningIndex];

            //Car Maximum Prices
            MaximumPrices = new ObservableCollection<string>(prices);
            MaximumPrices.Insert(Constants.BeginningIndex, Constants.NoPrice);
            SelectedMaximumPrice = MaximumPrices[Constants.BeginningIndex];

            //Car  Mileages
            var mileages = App.Database.Cars.Select(c => c.Mileage.ToString() + " " + Constants.Kilometer).Distinct();

            //Car Minimum Mileages
            MinimumMileages = new ObservableCollection<string>(mileages);
            MinimumMileages.Insert(Constants.BeginningIndex, Constants.NoMileage);
            SelectedMinimumMileage = MinimumMileages[Constants.BeginningIndex];

            //Car Maximum Mileages
            MaximumMileages = new ObservableCollection<string>(mileages);
            MaximumMileages.Insert(Constants.BeginningIndex, Constants.NoMileage);
            SelectedMaximumMileage = MaximumMileages[Constants.BeginningIndex];

            // Car Years
            var years = App.Database.Cars.Select(c => c.Year.ToString()).Distinct();

            // Car Minimum Years 
            MinimumYears = new ObservableCollection<string>(years);
            MinimumYears.Insert(Constants.BeginningIndex, Constants.NoYear);
            SelectedMinimumYear = MinimumYears[Constants.BeginningIndex];

            // Car Minimum Years 
            MaximumYears = new ObservableCollection<string>(years);
            MaximumYears.Insert(Constants.BeginningIndex, Constants.NoYear);
            SelectedMaximumYear = MaximumYears[Constants.BeginningIndex];
        }

    }
}
