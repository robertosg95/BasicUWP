using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Boolean plus = false;
        Boolean minus = false;
        Boolean times = false;
        Boolean div = false;

        double[] numbers = new double[20];
        double resultado;


        public MainPage()
        {

            this.InitializeComponent();

            result.Text = 0.ToString();
        }

        private void AddNumberToResult(double number)
        {
            if (char.IsNumber(result.Text.Last()))
            {
                if (result.Text.Length == 1 && result.Text == "0")
                {
                    result.Text = string.Empty;
                }
                result.Text += number;
            }
            else
            {
                if (number != 0)
                {
                    result.Text += number;
                }
            }
        }

        enum Operation { MINUS = 1, PLUS = 2, DIV = 3, TIMES = 4, NUMBER = 5 }
        private void AddOperationToResult(Operation operation)
        {
            if (result.Text.Length == 1 && result.Text == "0") return;

            if (!char.IsNumber(result.Text.Last()))
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }

            switch (operation)
            {
                case Operation.MINUS:
                    minus = true;
                    numbers[0] = Convert.ToDouble(result.Text);
                    result.Text = "0";
                    break;
                case Operation.PLUS:
                    plus = true;
                    numbers[0] = Convert.ToDouble(result.Text);
                    result.Text = "0";
                    break;
                case Operation.DIV:
                    div = true;
                    numbers[0] = Convert.ToDouble(result.Text);
                    result.Text = "0";
                    break;
                case Operation.TIMES:
                    times = true;
                    numbers[0] = Convert.ToDouble(result.Text);
                    result.Text = "0";
                    break;
            }
        }
        

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(7);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(9);
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.DIV);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(6);
        }

        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.TIMES);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(3);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.MINUS);
        }


        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            numbers[1] = Convert.ToDouble(result.Text);
            if (plus == true)
            {
                resultado = numbers[0] + numbers[1];
                history.Text += "\n" + numbers[0] + "+" + numbers[1] + "=" + resultado.ToString();
                textResult.Text = numbers[0] + "+" + numbers[1] + "=" + resultado.ToString();
                result.Text = "0";
                plus = false;
            }
            if (minus == true)
            {
                resultado = numbers[0] - numbers[1];
                history.Text += "\n" + numbers[0] + "-" + numbers[1] + "=" + resultado.ToString();
                textResult.Text = numbers[0] + "-" + numbers[1] + "=" + resultado.ToString();
                result.Text = "0";
                minus = false;
            }
            if (times == true)
            {
                resultado = numbers[0] * numbers[1];
                history.Text += "\n" + numbers[0] + "x" + numbers[1] + "=" + resultado.ToString();
                textResult.Text = numbers[0] + "x" + numbers[1] + "=" + resultado.ToString();
                result.Text = "0";
                times = false;
            }
            if (div == true)
            {
                resultado = numbers[0] / numbers[1];
                history.Text += "\n" + numbers[0] + "/" + numbers[1] + "=" + resultado.ToString();
                textResult.Text = numbers[0] + "/" + numbers[1] + "=" + resultado.ToString();
                result.Text = "0";
                div = false;
            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(0);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            result.Text = 0.ToString();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.PLUS);
        }

        private void btnExplanation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Explanation));
        }
    }
}
