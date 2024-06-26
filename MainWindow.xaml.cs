﻿using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            lblEquation.Content += btn.Content.ToString();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            string equation = lblEquation.Content.ToString();

            try
            {
                if (equation.Contains("^"))
                {
                    string[] temp = equation.Split("^");
                    double pow = Math.Pow(Convert.ToDouble(temp[0]), Convert.ToDouble(temp[1]));
                    lblOutput.Content = pow.ToString();
                }
                else
                {
                    if (equation.Contains("√"))
                    {
                        string temp = equation.Replace("√", "");
                        double root = Math.Sqrt(Convert.ToDouble(temp));
                        lblOutput.Content = root.ToString();
                    }
                    else
                    {
                        var result = new DataTable().Compute(equation, null);
                        lblOutput.Content = result.ToString();
                    }
                }
            }
            catch (Exception){lblOutput.Content = "Math Error!";}
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            string data = lblEquation.Content.ToString();
            if (data.Length > 0)
            {
                data = data.Remove(data.Length - 1);
                lblEquation.Content = data.ToString();
            }
        }

        private void Button_ClearAll(object sender, RoutedEventArgs e)
        {
            lblOutput.Content = string.Empty;
            lblEquation.Content = string.Empty;
        }

        private void Chb_CheckedChange(object sender, RoutedEventArgs e)
        {
            if(Chb.IsChecked == true)
            {
                BtnPower.Visibility = Visibility.Visible;
                BtnRoot.Visibility = Visibility.Visible;
            }
            else
            {
                BtnPower.Visibility = Visibility.Hidden;
                BtnRoot.Visibility = Visibility.Hidden;
            }

        }

        private void Button_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Corrently aavailiable functions: \n Summation, Substraction, Multiplication, Division.\n These operations can be used in in long equations or by themselves and the order of operations apply to them. You can also work with fractions.\n\n There is an availiable Exponentiation and Square root function but they can be only used by themselves. To access them tick the Scientific checkbox \n\n The CA button means: Clear All, and the C button means: Clear (it removes the last pressed button).","Calculator",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}