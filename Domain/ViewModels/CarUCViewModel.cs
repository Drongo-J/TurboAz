using ADO.NET_Task9.Domain.Helpers;
using ADO.NET_Task9.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ADO.NET_Task9.Domain.ViewModels
{
    public class CarUCViewModel : BaseViewModel
    {
        private string imageSource;

        public string ImageSource
        {
            get { return "https://media.ed.edmunds-media.com/bmw/3-series/2023/oem/2023_bmw_3-series_sedan_330i-xdrive_fq_oem_1_815.jpg"; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        public Car Car { get; set; }

        public string Price { get; set; }

        public string CarDetails { get; set; }

        public CarUCViewModel(Car car)
        {
            Car = car;
            Price = Car.Price.ToString() + " " + Constants.DollarSign;
            CarDetails = Car.Year + ", " + Car.FuelType + ", " + Car.Mileage + " " + Constants.Kilometer;
            //ImageSource = ImageHelpers.StringToImageSource(Car.ImagePath);
        }
    }
}
