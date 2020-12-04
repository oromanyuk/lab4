using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fio = Fio.Text;
            string data = Data.Text;
            string tel = Tel.Text;
            string mail = Mail.Text;

            string[] sl = fio.Split(' ');
            if (Fio.Text == "") MessageBox.Show("Введите ФИО.");
            else
            {
                if (sl.Length == 2 || sl.Length == 3)
                {
                    for (int i = 0; i < sl.Length; i++)
                    {
                        string bu = Convert.ToString(sl[i][0]);
                        if (bu == bu.ToUpper())
                        {
                            Fio.Clear();
                            Fio_Copy.Text = fio;
                        }
                        else MessageBox.Show("Проверьте правильность написания ФИО.");
                    }
                }
                else MessageBox.Show("Проверьте правильность написания ФИО.");
            }

            int tk = 0;
            string number = "0123456789";
            if (Tel.Text == "") MessageBox.Show("Введите номер телефона.");
            else
            {
                if ("+".CompareTo(Convert.ToString(tel[0])) == 0)
                {
                    for (int i = 1; i < tel.Length; i++)
                    {
                        for (int j = 0; j < number.Length; j++)
                            if (tel[i] == number[j]) tk++;
                    }
                    if (tk == 11)
                    {
                        Tel.Clear();
                        Tel_Copy.Text = tel;
                    }
                    else MessageBox.Show("Проверьте правильность написания номера телефона.");
                }
                else
                {
                    for (int i = 0; i < tel.Length; i++)
                    {
                        for (int j = 0; j < number.Length; j++)
                            if (tel[i] == number[j]) tk++;
                    }
                    if (tk == 11)
                    {
                        Tel.Clear();
                        Tel_Copy.Text = tel;
                    }
                    else MessageBox.Show("Проверьте правильность написания номера телефона.");
                }
            }

            if (Data.Text == "") MessageBox.Show("Введите дату рождения.");
            else
            {
                int osh = 0;
                string[] chisla = data.Split('.');
                for (int g = 0; g < chisla.Length; g++)
                    for (int i = 0; i < chisla[g].Length; i++)
                        if (Convert.ToChar(chisla[g][i]) < 48 || 57 < Convert.ToChar(chisla[g][i])) osh++;
                if (osh == 0)
                {
                    if (Convert.ToInt32(chisla[0]) < 1 || Convert.ToInt32(chisla[0]) > 31)
                    {
                        MessageBox.Show("Проверьте правильность написания даты рождения.");
                        Data_Copy.Clear();
                    }
                    else if (Convert.ToInt32(chisla[1]) < 1 || Convert.ToInt32(chisla[1]) > 12)
                    {
                        MessageBox.Show("Проверьте правильность написания даты рождения.");
                        Data_Copy.Clear();
                    }
                    else if (Convert.ToInt32(chisla[2]) < 1 || Convert.ToInt32(chisla[2]) > 2021)
                    {
                        MessageBox.Show("Проверьте правильность написания даты рождения.");
                        Data_Copy.Clear();
                    }
                    else
                    {
                        Data.Clear();
                        Data_Copy.Text = data;
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте правильность написания даты рождения.");
                    Data_Copy.Clear();
                }
            }

            if (Mail.Text == "") MessageBox.Show("Введите e-mail.");
            else
            { 
            string[] m1 = mail.Split('@');
            string[] toch = m1[m1.Length - 1].Split('.');
                if (m1.Length != 2)
                {
                    MessageBox.Show("Проверьте правильность написания e-mail.");
                    Mail_Copy.Clear();
                }
                else if (m1[0].Length < 1 || m1[1].Length < 1)
                {
                    MessageBox.Show("Проверьте правильность написания e-mail.");
                    Mail_Copy.Clear();
                }
                else if (toch.Length != 2)
                {
                    MessageBox.Show("Проверьте правильность написания e-mail.");
                    Mail_Copy.Clear();
                }
                else if (toch[0].Length < 1 || toch[1].Length < 1)
                {
                    MessageBox.Show("Проверьте правильность написания e-mail.");
                    Mail_Copy.Clear();
                }
                else
                {
                    for (int i = 0; i < m1.Length; i++)
                    {
                        for (int j = 0; j < m1[i].Length; j++)
                        {
                            if (((Convert.ToChar(m1[i][j]) < 97 || 122 < Convert.ToChar(m1[i][j])) && (Convert.ToChar(m1[i][j]) < 48 || 57 < Convert.ToChar(m1[i][j]))) && m1[i][j] + "" != ".")
                            {
                                MessageBox.Show("Проверьте правильность написания e-mail.");
                                Mail_Copy.Clear();
                                break;
                            }
                            else if (j == 0 && m1[i][j] + "" == ".")
                            {
                                MessageBox.Show("Проверьте правильность написания e-mail.");
                                Mail_Copy.Clear();
                                break;
                            }
                            else if (j == m1[i].Length - 1 && m1[i][j] + "" == ".")
                            {
                                MessageBox.Show("Проверьте правильность написания e-mail.");
                                Mail_Copy.Clear();
                                break;
                            }
                            else
                            {
                                Mail.Clear();
                                Mail_Copy.Text = mail;
                            }
                        }
                    }
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Fio.Clear();
            Data.Clear();
            Tel.Clear();
            Mail.Clear();
        }

        private void Clear_spisok_Click(object sender, RoutedEventArgs e)
        {
            Fio_Copy.Clear();
            Data_Copy.Clear();
            Tel_Copy.Clear();
            Mail_Copy.Clear();
        }
    }
}
