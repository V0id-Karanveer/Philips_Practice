using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Prism.Mvvm;
using Prism.Commands;

namespace Calc
{
    public class MainWindowViewModel : BindableBase
    {
        private double lastNumber;
        private double result;
        private SelectedOp op;
        private string _resultLabel;

        public string resultLabel { get => resultLabel;
            set => SetProperty(ref _resultLabel, value); }

        public DelegateCommand<string> Btnclick { get; private set; }
        public DelegateCommand<string> OpClick { get; private set; }
        public DelegateCommand<string> FuncClick { get; private set; }


        public MainWindowViewModel()
        {
            resultLabel = 0;

        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (op)
                {
                    case SelectedOp.Add:
                        result = SimpleMath.add(lastNumber, newNumber);
                        break;
                    case SelectedOp.Sub:
                        result = SimpleMath.sub(lastNumber, newNumber);
                        break;
                    case SelectedOp.Mul:
                        result = SimpleMath.mul(lastNumber, newNumber);
                        break;
                    case SelectedOp.Div:
                        result = SimpleMath.div(lastNumber, newNumber);
                        break;
                }

            }
            resultLabel.Content = result.ToString();
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void Negetive_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void Operations_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == Plus)
            {
                op = SelectedOp.Add;
            }
            else if (sender == Minus)
            {
                op = SelectedOp.Sub;
            }
            else if (sender == Multiply)
            {
                op = SelectedOp.Mul;
            }
            else if (sender == Divide)
            {
                op = SelectedOp.Div;
            }
        }

        private void Button_Click(string s)
        {
            if (resultLabel == "0")
            {
                resultLabel = s;
            }
            else
            {
                resultLabel = $"{resultLabel}{s}";
            }
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }

        }
    }

    public enum SelectedOp
    {
        Add,
        Sub,
        Mul,
        Div
    }

    public class SimpleMath
    {
        public static double add(double a, double b)
        {
            return a + b;
        }

        public static double sub(double a, double b)
        {
            return a - b;
        }

        public static double mul(double a, double b)
        {
            return a * b;
        }

        public static double div(double a, double b)
        {
            if (b == 0)
            {
                MessageBox.Show("Divison by 0 Error", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return a / b;
        }
    }
}

