using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MVVM_Prac.Model;
using MVVM_Prac.ViewModel.Helpers;
using Prism.Commands;
using Prism.Mvvm;

namespace MVVM_Prac.ViewModel
{
    public class WeatherVM : BindableBase

    {
        private string query;
        AccuWeatherHelper api = new AccuWeatherHelper();
        public string Query
        {
            get { return query; }
            set { SetProperty(ref query, value); }
        }

        private ObservableCollection<City> cities;

        public ObservableCollection<City> Cities
        {
            get
            {
                return cities;
            }
            set
            {
                SetProperty(ref cities, value);
            }
        }


        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                SetProperty(ref currentConditions, value);
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                SetProperty(ref selectedCity, value);
                GetCurrentConditions();
            }
        }

        public DelegateCommand SearchCommand { get; private set; }

        public WeatherVM()
        {
            SearchCommand = new DelegateCommand(MakeQuery);
            Cities = new ObservableCollection<City>();
           
        }

        public async void MakeQuery()
        {
            List<City> cities = await api.GetCities(Query);
            Cities.Clear();
            foreach (City c in cities)
            {
                Cities.Add(c);
            }
        }

        public async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();
            CurrentConditions = await api.GetCurrentConditions(SelectedCity.Key);
        }
    }
}
