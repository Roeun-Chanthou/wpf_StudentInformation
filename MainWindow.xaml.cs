using StudentInformation.Pages;
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

namespace StudentInformation
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private Button _currentSelectedButton;
        public MainWindow()
        {
            InitializeComponent();
            Directory.CreateDirectory("Data");

            AddPage(new Pages.RegisterPage());
            SetButtonSelected(ButtonRegister);


        }

        public void AddPage(UserControl page)
        {
            GridPage.Children.Clear();
            GridPage.Children.Add(page);
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var RegisterPage = new RegisterPage();

            AddPage(RegisterPage);
            SetButtonSelected(ButtonRegister);


        }

        private void ButtonStudentData_Click(object sender, RoutedEventArgs e)
        {
            var StudentPage = new StudentDataPage();
            AddPage(StudentPage);
            SetButtonSelected(ButtonStudentData);
        }

        private void ButtonMyGroup_Click(object sender, RoutedEventArgs e)
        {
            var MyGroup = new MyGroup();

            AddPage(MyGroup);
            SetButtonSelected(ButtonMyGroup);

            MyGroup.LoadMyGroupData();
        }
        private void SetButtonSelected(Button selectedButton)
        {
            if (_currentSelectedButton != null)
            {
                _currentSelectedButton.ClearValue(Button.BackgroundProperty);
                _currentSelectedButton.ClearValue(Button.ForegroundProperty);
            }

            selectedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#454444"));
            selectedButton.Foreground = Brushes.White;
            _currentSelectedButton = selectedButton;
        }
    }
}


