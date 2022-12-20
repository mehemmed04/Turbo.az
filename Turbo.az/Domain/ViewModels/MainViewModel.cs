using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az.Commands;
using Turbo.az.Domain.Entities;

namespace Turbo.az.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }
        public List<string> Models { get; set; }
        public List<string> Colors { get; set; }
        public List<string> Bans { get; set; }
        public List<string> FuelTypes { get; set; }

        public RelayCommand ShowCommand { get; set; }
        private string selectedBrand;

        public string SelectedBrand
        {
            get { return selectedBrand; }
            set { selectedBrand = value; OnPropertyChanged(); }
        }
        private string selectedBan;

        public string SelectedBan
        {
            get { return selectedBan; }
            set { selectedBan = value; OnPropertyChanged(); }
        }

        private string selectedColor;

        public string SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; OnPropertyChanged(); }
        }
        private string selectedFuel;

        public string SelectedFuel
        {
            get { return selectedFuel; }
            set { selectedFuel = value; OnPropertyChanged(); }
        }

        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; OnPropertyChanged(); }
        }
        private string minPrice;

        public string MinPrice
        {
            get { return minPrice; }
            set { minPrice = value; OnPropertyChanged(); }
        }

        private string maxPrice;

        public string MaxPrice
        {
            get { return maxPrice; }
            set { maxPrice = value; OnPropertyChanged(); }
        }
        private string minkm;

        public string Minkm
        {
            get { return minkm; }
            set { minkm = value; OnPropertyChanged(); }
        }

        private string maxkm;

        public string Maxkm
        {
            get { return maxkm; }
            set { maxkm = value; OnPropertyChanged(); }
        }




        public MainViewModel()
        {
            Cars = App.DB.CarRepository.GetAll().ToList();

            Models = new List<string>();
            Colors = new List<string>();
            Bans = new List<string>();
            FuelTypes = new List<string>();

            var cars = App.DB.CarRepository.GetAll().ToList();

            foreach (var item in cars)
            {
                Models.Add(item.Brand);
                Colors.Add(item.Color);
                Bans.Add(item.Type);
                FuelTypes.Add(item.FuelType);
            }
            Models = Models.Distinct().ToList();
            Colors = Colors.Distinct().ToList();
            Bans = Bans.Distinct().ToList();
            FuelTypes = FuelTypes.Distinct().ToList();

            ShowCommand = new RelayCommand((o) =>
            {
                var allcars = App.DB.CarRepository.GetAll().ToList();
                if (selectedBrand != null)
                {
                    allcars = allcars.Where((c) => { return c.Brand == selectedBrand; }).ToList();
                }
                if (selectedBan != null)
                {
                    allcars = allcars.Where((c) => { return c.Type == selectedBan; }).ToList();
                }
                if (minPrice != null && minPrice != String.Empty)
                {
                    int price = Convert.ToInt32(minPrice);
                    allcars = allcars.Where((c) => { return c.Price >= price; }).ToList();
                }
                if (maxPrice != null && maxPrice != String.Empty)
                {
                    int price = Convert.ToInt32(maxPrice);
                    allcars = allcars.Where((c) => { return c.Price <= price; }).ToList();
                }
                if (Minkm != null && Minkm!=String.Empty)
                {
                    int km = Convert.ToInt32(minkm);
                    allcars = allcars.Where((c) => { return c.Mileage >= km; }).ToList();
                }
                if (Maxkm != null && Maxkm != String.Empty)
                {
                    int km = Convert.ToInt32(Maxkm);
                    allcars = allcars.Where((c) => { return c.Mileage <= km; }).ToList();
                }
                if (isNew == true)
                {
                    allcars = allcars.Where((c) => { return c.IsNew; }).ToList();
                }
                if (SelectedColor != null)
                {
                    allcars = allcars.Where((c) => { return c.Color == SelectedColor; }).ToList();
                }
                if (SelectedFuel != null)
                {
                    allcars = allcars.Where((c) => { return c.FuelType == SelectedFuel; }).ToList();
                }
                Cars = allcars;
            });
        }
    }
}
