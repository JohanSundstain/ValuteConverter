using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BankConverter.Cache;
using BankConverter.Model;
using BankConverter.Repository;
using BankConverter.View;

namespace BankConverter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private IRestRepository restRepository;

        private SimpleCache<ValCurs> _cache;
        // Обработка нажатия кнопки 
        private Commander _swap;
        public Commander Swap 
        {
            get => _swap ?? (_swap = new Commander(
                obj =>
                {
                    ValCursValute tmp = FirstSelectedValue;
                    FirstSelectedValue = SecondSelectedValue;
                    SecondSelectedValue = tmp;
                }));
        }

        private double _firstValute;
        public double FirstValute
        {
            get => _firstValute;
            set
            {
                _firstValute = value;
                OnPropertyChanged(nameof(FirstValute));
            }
        }

        private double _num1;
        public double num1
        {
            get => _num1;
            set
            {
                _num1 = value;
                OnPropertyChanged("num2");
            }
        }

        private double _num2;
        public double num2
        {
            get => Math.Round(num1 * (FirstValute / SecondValue),2);
            set
            {
                _num2 = value;
                OnPropertyChanged("num1");
            }
           
        }

        private double _secondValue;
        public double SecondValue
        {
            get => _secondValue;
            set
            {
                _secondValue = value;
                OnPropertyChanged(nameof(SecondValue));
            }

        }

        private ValCurs _valuteField;
        public ValCurs Valute
        {
            get => _valuteField;
            set
            {
                _valuteField = value;
                OnPropertyChanged(nameof(Valute));
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                LoadView(value);
            }
        }

        private ValCursValute _secondSelectedValue;
        public ValCursValute SecondSelectedValue
        {
            get => _secondSelectedValue;
            set
            {
                if (value == null)
                {
                    return;
                }
                _secondSelectedValue = value;
                OnPropertyChanged(nameof(SecondSelectedValue));
                SecondValue = Double.Parse(value.Value);
                num1 = num1;

            }
        }

        private ValCursValute _firstSelectedValue;
        public ValCursValute FirstSelectedValue
        {
            get => _firstSelectedValue;
            set
            {
                if (value == null)
                {
                    return;
                }

                _firstSelectedValue = value;
                OnPropertyChanged(nameof(FirstSelectedValue));
                FirstValute = Double.Parse(value.Value);
                num1 = num1;
            }
        }

        //Конструктор
        public MainViewModel()
        {
            restRepository = new RestRepository();
            _cache = new SimpleCache<ValCurs>();
            SelectedDate = DateTime.Today;
            LoadView(SelectedDate);
        }

        private async void LoadView(DateTime? selectedTime)
        {
            num1 = 1;
            // Реализация кэша
            // Если в кеше есть запись по этой дате
            if (_cache.HasIt(selectedTime.Value))
            {
                // Берём валюты из кеша
                Valute = _cache.Get(selectedTime.Value);
            }
            else
            {
                // Иначе делаем запрос
                Valute = await restRepository.GetCurs(selectedTime);
                // Помещаем в кеш
                _cache.Set(selectedTime.Value, Valute);
            }
            
            FirstSelectedValue = Valute.Valute[0];
            SecondSelectedValue = Valute.Valute[2];
        }
    }
}
