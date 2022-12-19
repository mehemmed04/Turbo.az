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
        public MainViewModel()
        {
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
                Cars = App.DB.CarRepository.GetAll().ToList();
            });
        }
    }
}
