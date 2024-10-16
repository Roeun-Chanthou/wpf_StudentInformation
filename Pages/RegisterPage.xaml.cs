using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StudentInformation.Pages
{
    public partial class RegisterPage : UserControl
    {
        private string _selectedImagePath;

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
          
            string imageDirectory = "Data/StudentImages";
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            string newImagePath = string.Empty;

           

            if (!string.IsNullOrEmpty(_selectedImagePath))
            {
                string imageFileName = $"{TextBoxID.Text}_{Path.GetFileName(_selectedImagePath)}";
                newImagePath = Path.Combine(imageDirectory, imageFileName);

                File.Copy(_selectedImagePath, newImagePath, true);
            }
            if (TextBoxFirtName.Text == "" || TextBoxLastName.Text == "" || TextBoxID.Text == "" || TextBoxMajor.Text == "" || TextBoxPhoneNumber.Text == "" || TextBoxGender.Text == "" || newImagePath == "")
            {
                MessageBox.Show("You Have to Input all Data","Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
 
            string[] data = new string[]
            {
                TextBoxID.Text,
                $"{TextBoxFirtName.Text} {TextBoxLastName.Text}",
                TextBoxGender.Text,
                TextBoxMajor.Text,
                TextBoxPhoneNumber.Text,
                newImagePath 
            };

 
            using (StreamWriter writer = new StreamWriter("Data/Student.txt", true))
            {
                writer.WriteLine(string.Join(";", data));
            }

            ClearForm();

            MessageBox.Show("Student information saved successfully!","Success",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClearForm()
        {
            TextBoxID.Text = TextBoxFirtName.Text = TextBoxLastName.Text = TextBoxGender.Text = TextBoxMajor.Text = TextBoxPhoneNumber.Text = string.Empty;
            UploadedImage.Source = null;
            _selectedImagePath = string.Empty;
        }

        private void ButtonUploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImagePath = openFileDialog.FileName;

             
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(_selectedImagePath);
                bitmap.EndInit();
                UploadedImage.Source = bitmap;
            }
        }
    }
}

