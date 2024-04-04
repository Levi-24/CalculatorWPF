using System.Data;
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
                    string temp = equation.Replace("√","");
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
    }
}