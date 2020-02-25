using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double mem;
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
                String op; //operator
                int iOp = 0; //pozycja operatora
                if (poleTekstowe.Text.Contains("+"))
                {
                    iOp = poleTekstowe.Text.IndexOf("+");
                }
                else if (poleTekstowe.Text.Contains("-"))
                {
                    iOp = poleTekstowe.Text.IndexOf("-");
                    if (iOp == 0)
                    {
                        iOp = poleTekstowe.Text.IndexOf("-", poleTekstowe.Text.IndexOf("-") + 1);
                    }
                }
                else if (poleTekstowe.Text.Contains("*"))
                {
                    iOp = poleTekstowe.Text.IndexOf("*");
                }
                else if (poleTekstowe.Text.Contains("/"))
                {
                    iOp = poleTekstowe.Text.IndexOf("/");
                }
                else if (poleTekstowe.Text.Contains("^"))
                {
                    iOp = poleTekstowe.Text.IndexOf("^");
                }
                else
                {
                    poleTekstowe.Text = "Error znaku";
                }

                op = poleTekstowe.Text.Substring(iOp, 1);
                double liczba1;
                double liczba2;

                if (poleTekstowe.Text.IndexOf("-") == 0)
                {
                    liczba1 = -Convert.ToDouble(poleTekstowe.Text.Substring(0, iOp));
                    liczba2 = -Convert.ToDouble(poleTekstowe.Text.Substring(iOp + 1, poleTekstowe.Text.Length - iOp - 1));
                }
                else
                {
                    liczba1 = Convert.ToDouble(poleTekstowe.Text.Substring(0, iOp));
                    liczba2 = Convert.ToDouble(poleTekstowe.Text.Substring(iOp + 1, poleTekstowe.Text.Length - iOp - 1));
                }

                switch (op)
                {
                    case "+":
                        poleTekstowe.Text = Convert.ToString(liczba1 + liczba2);
                        break;
                    case "-":
                        poleTekstowe.Text = Convert.ToString(liczba1 - liczba2);
                        break;
                    case "*":
                        poleTekstowe.Text = Convert.ToString(liczba1 * liczba2);
                        break;
                    case "/":
                        poleTekstowe.Text = Convert.ToString(liczba1 / liczba2);
                        break;
                    case "^":
                        poleTekstowe.Text = Convert.ToString(Math.Pow(liczba1, liczba2));
                        break;
                    default:
                        poleTekstowe.Text = "Error convert";
                        break;
                }
            }
            catch
            {
                poleTekstowe.Text = "Error";
            }
        }
        private void Mem_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            try
            {
                if (b.Content.ToString() == "MR")
                {
                    poleTekstowe.Text = Convert.ToString(mem);
                }
                if (b.Content.ToString() == "MRC")
                {
                    mem = 0;
                }
                if (b.Content.ToString() == "MR+")
                {
                    mem += Convert.ToDouble(poleTekstowe.Text);
                }
                if (b.Content.ToString() == "MR-")
                {
                    mem -= Convert.ToDouble(poleTekstowe.Text);
                }
            }
            catch
            {
                poleTekstowe.Text = "Error";
            }
        }
    }
}
