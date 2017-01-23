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

namespace Wpf2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;
        public MainWindow()
        {
            controller = Controller.GetInstance();
            InitializeComponent();
        }

        private void ClearTextBoxes() {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxAge.Text = "";
            textBoxTelephone.Text = "";
            PersonCount.Content = controller.PersonCount;
            Index.Content = controller.PersonIndex;
        } 

        private void UpdateWindow() {
            PersonCount.Content = controller.PersonCount;
            Index.Content = controller.PersonIndex;
            textBoxFirstName.Text = controller.GetFirstname();
            textBoxLastName.Text = controller.GetLastName();
            textBoxAge.Text = controller.GetAge();
            textBoxTelephone.Text = controller.GetTelephone();
        }

        private void buttonNew_Click(object sender, RoutedEventArgs e) {
            controller.AddPerson(textBoxFirstName.Text, textBoxLastName.Text, textBoxAge.Text, textBoxTelephone.Text);
            ClearTextBoxes();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e) {
            controller.DeletePerson();
            UpdateWindow();
        }

        private void buttonUp_Click(object sender, RoutedEventArgs e) {
            controller.PrevPerson();
            UpdateWindow();
        }

        private void buttonDown_Click(object sender, RoutedEventArgs e) {
            controller.NextPerson();
            UpdateWindow();
        }
    }
}
