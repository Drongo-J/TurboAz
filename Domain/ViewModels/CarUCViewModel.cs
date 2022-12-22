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
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        public Car Car { get; set; }

        public string Price { get; set; }

        public string CarDetails1 { get; set; }
        public string CarDetails2 { get; set; }
        public string CarDetails3 { get; set; }

        public CarUCViewModel(Car car)
        {
            Car = car;
            Price = Car.Price.ToString() + " " + Constants.DollarSign;

            var str = string.Empty;
            if (Car.IsNew)
                str = "New";
            else
                str = "Old";

            if (Car.Color.Trim() == string.Empty)
                CarDetails1 = "No Info";
            else
                CarDetails1 = Car.Color;
            CarDetails3 = str;
            CarDetails2 = Car.Year + ", " + Car.FuelType + ", " + Car.Mileage + " " + Constants.Kilometer;
            ImageSource = @"\Domain\Images\carImage.jpeg";
        }
    }
}
