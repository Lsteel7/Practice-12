using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practice_12
{
    public partial class MainWindow : Window
    {
        private int[] mas;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string input = vvodEl.Text.Trim();
            string[] parts = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            mas = Array.ConvertAll(parts, int.Parse);

            MassivListBox.Items.Clear();
            foreach (var number in mas)
            {
                MassivListBox.Items.Add(number);
            }
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            int max = mas.Max();
            int min = mas.Min();
            int sum = mas.Sum();
            double avg = mas.Average();

            outputTextBox.Text = $"Max: {max}, Min: {min}, Sum: {sum}, Avg: {avg:F2}";
        }

        private void AnyButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(vvodEl.Text, out int element))
            {
                bool exists = mas.Any(x => x == element);
                MessageBox.Show(exists ? "Элемент найден." : "Элемент не найден.");
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            mas = null;
            MassivListBox.Items.Clear();
            outputTextBox.Text = "";
            MessageBox.Show("Массив очищен.");
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            int[] copy = (int[])mas.Clone();
            MessageBox.Show("Массив скопирован.");
        }

        private void ExistsButton_Click(object sender, RoutedEventArgs e)
        {
            AnyButton_Click(sender, e);
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(vvodEl.Text, out int element))
            {
                int index = Array.IndexOf(mas, element);
                if (index >= 0)
                    MessageBox.Show($"Элемент найден на индексе: {index}");
                else
                    MessageBox.Show("Элемент не найден.");
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
        }

        private void FindAllButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(vvodEl.Text, out int element))
            {
                var indices = mas.Select((value, index) => new { value, index })
                                 .Where(x => x.value == element)
                                 .Select(x => x.index)
                                 .ToList();

                if (indices.Count > 0)
                    MessageBox.Show($"Элемент найден на индексах: {string.Join(", ", indices)}");
                else
                    MessageBox.Show("Элемент не найден.");
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
        }
        private void IndexButton_Click(object sender, RoutedEventArgs e)
        {
            FindButton_Click(sender, e);
        }
        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(vvodEl.Text, out int newSize))
            {
                Array.Resize(ref mas, newSize);
                MessageBox.Show($"Размер массива изменен на: {newSize}");
            }
            else
            {
                MessageBox.Show("Введите корректный размер массива.");
            }
        }
        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            Array.Reverse(mas);
            MassivListBox.Items.Clear();
            foreach (var number in mas)
            {
                MassivListBox.Items.Add(number);
            }
            MessageBox.Show("Массив развернут.");
        }
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            Array.Sort(mas);
            MassivListBox.Items.Clear();
            foreach (var number in mas)
            {
                MassivListBox.Items.Add(number);
            }
            MessageBox.Show("Массив отсортирован.");
        }
    }
}



