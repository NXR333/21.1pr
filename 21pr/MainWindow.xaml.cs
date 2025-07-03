using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace pr21
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<NumberItem> Numbers { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            NumbersGrid.ItemsSource = Numbers;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(CountTextBox.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Введите корректное положительное целое число");
                return;
            }

            var rand = new Random();
            Numbers.Clear();
            for (int i = 0; i < count; i++)
            {
                Numbers.Add(new NumberItem { Value = rand.Next(-100, 101) });
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int sum = Numbers.Where(n => n.Value % 5 == 0).Sum(n => n.Value);
            ResultTextBox.Text = sum.ToString();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Селезнев Никита Денисович\n" +
                            "ИСП-22",
                            "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Numbers.Clear();
            ResultTextBox.Clear();
        }
    }
    public class NumberItem
    {
        public int Value { get; set; }
    }
}
