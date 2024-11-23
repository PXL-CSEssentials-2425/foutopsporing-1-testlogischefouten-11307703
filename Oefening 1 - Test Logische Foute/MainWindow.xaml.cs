using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oefening_1___Test_Logische_Foute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        private string imageFolderPath = @"C:\Users\Tolga Guclu\Desktop\Programmeren\C# Essentials\Repos\Hoofdstuk 10 - Foutopsporing";
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void startButton_Click(object sender, EventArgs e)

        {
            TestFoutenTryCatch();
           
        }

        private void TestFoutenTryCatch()
        {
            try
            {
                int product = 0;
                int counter = 1;
                int number = 0;
                resultTextBox.Text = "";

                number = int.Parse(numberTextBox.Text);
                while (product <= 1000 || counter <= 51)
                {
                    product = number * counter;
                    resultTextBox.Text += $"{counter} x {number} = {product}\n";
                    counter++;
                }
            }
            catch (FormatException xx)
            {               
                MessageBox.Show($"Format exception: {xx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void startButton2_Click(object sender, RoutedEventArgs e)
        {
            int product = 0;
            int counter = 1;
            int number = 0;
            resultTextBox.Text = "";

            number = int.Parse(numberTextBox.Text);
            while (product <= 1000 && counter <= 51)
            {
                resultTextBox.Text = resultTextBox.Text + counter.ToString() + " x " +
                number.ToString() + " = " + product.ToString() + "\r\n";
                counter++;
            }
        }

        private void startButtonCorrect_Click(object sender, RoutedEventArgs e)
        {
            double product = 0;
            double counter = 1;
            double number;
            resultTextBox.Text = "";

            if (!double.TryParse(numberTextBox.Text, out number))
            {
                MessageBox.Show("Geef een getal aub");
            }
            else
            {
                while (product <= 1000 && counter <= 51)
                {
                    product = counter * number;
                    resultTextBox.Text = resultTextBox.Text + counter.ToString() + " x " +
                    number.ToString() + " = " + product.ToString() + "\r\n";
                    counter++;
                }
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            numberTextBox.Clear();
            resultTextBox.Clear();
            numberTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void showImageButton_Click(object sender, RoutedEventArgs e)
        {
            int rndNumber = random.Next(0, 10);
            string imagePath = System.IO.Path.Combine(imageFolderPath, $"zee{rndNumber}.jpg");
            image.Source = new BitmapImage(new Uri(imagePath));
        }

        private void showImageWithCheckButton_Click(object sender, RoutedEventArgs e)
        {
            int rndNumber = random.Next(0, 10);
            string imagePath = System.IO.Path.Combine(imageFolderPath, $"zee{rndNumber}.jpg");
            image.Source = new BitmapImage(new Uri(imagePath));
            try
            {
                if (File.Exists(imagePath))
                {
                    image.Source = new BitmapImage(new Uri(imagePath));
                }
                else
                {
                    MessageBox.Show("Afbeelding niet gevonden");
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout: {ex.Message}", "Fout", MessageBoxButton.OK);
            }


        }
    }
}