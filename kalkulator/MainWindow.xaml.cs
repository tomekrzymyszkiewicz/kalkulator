using System;
using System.Windows;
using System.Windows.Controls;

namespace kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            poleTekstowe.Text += b.Content.ToString();
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            poleTekstowe.Text = "";
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (poleTekstowe.Text.Length > 0)
            {
                poleTekstowe.Text = poleTekstowe.Text.Substring(0, poleTekstowe.Text.Length - 1);
            }
        }

        private void OFF_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Wynik_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wynik();
            }
            catch
            {
                poleTekstowe.Text = "Error";
            }
        }

        private void wynik()
        {
            String op; //operator
            int iOp = 0; //pozycja operatora
            if(poleTekstowe.Text.Contains("+"))
            {
                iOp = poleTekstowe.Text.IndexOf("+");
            }
            else if(poleTekstowe.Text.Contains("-"))
            {
                iOp = poleTekstowe.Text.IndexOf("-");

            }
            else if (poleTekstowe.Text.Contains("*"))
            {
                iOp = poleTekstowe.Text.IndexOf("*");

            }
            else if (poleTekstowe.Text.Contains("/"))
            {
                iOp = poleTekstowe.Text.IndexOf("/");
            }
            else
            {
                poleTekstowe.Text = "Error";
            }

            op = poleTekstowe.Text.Substring(iOp, 1);
            double liczba1 = Convert.ToDouble(poleTekstowe.Text.Substring(0, iOp));
            double liczba2 = Convert.ToDouble(poleTekstowe.Text.Substring(iOp + 1, poleTekstowe.Text.Length - iOp - 1));

            switch (op)
            {
                case "+":
                    poleTekstowe.Text += "=" + (liczba1 + liczba2);
                    break;
                case "-":
                    poleTekstowe.Text += "=" + (liczba1 - liczba2);
                    break;
                case "*":
                    poleTekstowe.Text += "=" + (liczba1 * liczba2);
                    break;
                case "/":
                    poleTekstowe.Text += "=" + (liczba1 / liczba2);
                    break;
                default:
                    poleTekstowe.Text = "Error";
                    break;
            }
        }
    }
}
