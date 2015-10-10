namespace Hangman
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.SetHeightAndWidth(190, 245);
            this.HideEverything();
        }

        public void SetComboCategories() // (List<string> categories)
        {
            List<string> categories = new List<string>();
            categories.Add("cars");
            categories.Add("IT");
            categories.Add("dryn dryn");
            this.comboBoxCategory.ItemsSource = categories;
        }

        public void SetMessageLabel(string message)
        {
            this.labelMessages.Content = message;
        }

        private void ButtonName(object sender, RoutedEventArgs e)
        {
            this.SetHeightAndWidth(360, 245);

            this.buttonName.IsEnabled = false;
            this.textBoxName.IsEnabled = false;

            this.SetComboCategories();

            this.gridCategory.Visibility = Visibility.Visible;

            // Send name to class Player
        }

        private void ButtonKeyBoard_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            this.labelMessages.Content = button.Content;
            if (button.Content.ToString() != "Help")
            {
                button.IsEnabled = false;
            }

            // Send letters to some method to check out
        }

        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SetHeightAndWidth(360, 1000);

            this.gridPlayField.Visibility = Visibility.Visible;
        }

        private void SetHeightAndWidth(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        private void HideEverything()
        {
            this.gridCategory.Visibility = Visibility.Hidden;
            this.gridPlayField.Visibility = Visibility.Hidden;
        }
    }
}