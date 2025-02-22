using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Figures
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex _regex = new Regex(@"^[0-9]*(?:[.,]?[0-9]*)?$");

        public MainWindow()
        {
            InitializeComponent();

            ClearAllFields();
            ShowRelevantFields();
        }

        // Ограничиваем ввод только допустимыми символами
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string fullText = tb.Text.Insert(tb.SelectionStart, e.Text);
            e.Handled = !_regex.IsMatch(fullText);
        }

        // Очищаем все поля
        private void ClearAllFields()
        {
            tbSide1.Text = string.Empty;
            tbSide2.Text = string.Empty;
            tbSideA.Text = string.Empty;
            tbSideB.Text = string.Empty;
            tbSideC.Text = string.Empty;
            tbRadius.Text = string.Empty;
            tbResult.Text = string.Empty;
        }

        // Отображаем только нужные элементы в зависимости от выбранной фигуры
        private void ShowRelevantFields()
        {
            // Скрываем все элементы
            lblSide1.Visibility = Visibility.Collapsed;
            tbSide1.Visibility = Visibility.Collapsed;
            lblSide2.Visibility = Visibility.Collapsed;
            tbSide2.Visibility = Visibility.Collapsed;
            lblSideA.Visibility = Visibility.Collapsed;
            tbSideA.Visibility = Visibility.Collapsed;
            lblSideB.Visibility = Visibility.Collapsed;
            tbSideB.Visibility = Visibility.Collapsed;
            lblSideC.Visibility = Visibility.Collapsed;
            tbSideC.Visibility = Visibility.Collapsed;
            lblRadius.Visibility = Visibility.Collapsed;
            tbRadius.Visibility = Visibility.Collapsed;

            // Для прямоугольника используем поля "Ширина" и "Высота"
            if (rbRectangle.IsChecked == true)
            {
                lblSide1.Content = "Ширина:";
                lblSide2.Content = "Высота:";
                lblSide1.Visibility = Visibility.Visible;
                tbSide1.Visibility = Visibility.Visible;
                lblSide2.Visibility = Visibility.Visible;
                tbSide2.Visibility = Visibility.Visible;
            }

            // Для круга используем только "Радиус"
            else if (rbCircle.IsChecked == true)
            {
                lblRadius.Visibility = Visibility.Visible;
                tbRadius.Visibility = Visibility.Visible;
            }

            // Для треугольника по формуле Герона используем поля A, B, C
            else if (rbTriangle.IsChecked == true)
            {
                lblSideA.Visibility = Visibility.Visible;
                tbSideA.Visibility = Visibility.Visible;
                lblSideB.Visibility = Visibility.Visible;
                tbSideB.Visibility = Visibility.Visible;
                lblSideC.Visibility = Visibility.Visible;
                tbSideC.Visibility = Visibility.Visible;
            }
        }

        private void FigureType_Checked(object sender, RoutedEventArgs e)
        {
            ClearAllFields();
            ShowRelevantFields();
        }

        // Метод для парсинга строки в число с заменой разделителя
        private bool TryParseInput(string input, out double value) => double.TryParse(input.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Проверка: выбран ли тип фигуры
            if (rbRectangle.IsChecked == false && rbCircle.IsChecked == false && rbTriangle.IsChecked == false)
            {
                MessageBox.Show("Выберите вид фигуры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                double area = 0;

                // Прямоугольник
                if (rbRectangle.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(tbSide1.Text) || string.IsNullOrWhiteSpace(tbSide2.Text))
                    {
                        MessageBox.Show("Заполните ширину и высоту прямоугольника!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (!TryParseInput(tbSide1.Text, out double width) || !TryParseInput(tbSide2.Text, out double height))
                    {
                        MessageBox.Show("Ширина и высота должны быть числами!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (width <= 0 || height <= 0)
                    {
                        MessageBox.Show("Ширина и высота должны быть положительными!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    area = new RectangleFigure(width, height).GetArea();
                }

                // Круг
                else if (rbCircle.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(tbRadius.Text))
                    {
                        MessageBox.Show("Заполните радиус круга!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (!TryParseInput(tbRadius.Text, out double radius))
                    {
                        MessageBox.Show("Радиус должен быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (radius <= 0)
                    {
                        MessageBox.Show("Радиус должен быть положительным!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    area = new CircleFigure(radius).GetArea();
                }

                // Треугольник (по Герону)
                else if (rbTriangle.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(tbSideA.Text) ||
                        string.IsNullOrWhiteSpace(tbSideB.Text) ||
                        string.IsNullOrWhiteSpace(tbSideC.Text))
                    {
                        MessageBox.Show("Заполните все три стороны треугольника!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (!TryParseInput(tbSideA.Text, out double sideA) ||
                        !TryParseInput(tbSideB.Text, out double sideB) ||
                        !TryParseInput(tbSideC.Text, out double sideC))
                    {
                        MessageBox.Show("Стороны треугольника должны быть числами!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                    {
                        MessageBox.Show("Стороны треугольника должны быть положительными!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Проверка существования треугольника по неравенству сторон
                    if (sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideA + sideB)
                    {
                        MessageBox.Show("С указанными сторонами треугольник не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    area = new TriangleFigure(sideA, sideB, sideC).GetArea();
                }

                // Если вычисленная площадь некорректна, выводим предупреждение
                if (double.IsNaN(area) || area < 0)
                {
                    MessageBox.Show("Невозможно вычислить площадь с заданными значениями!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                tbResult.Text = area.ToString("F2", CultureInfo.InvariantCulture);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}



