using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StudentInformation.Components
{
    public partial class Data : UserControl, INotifyPropertyChanged
    {
        private string _imagePath;

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
                UpdateImage();
            }
        }

        public Data()
        {
            InitializeComponent();
            this.DataContext = this; 
        }

        private void UpdateImage()
        {
            if (!string.IsNullOrEmpty(_imagePath) && File.Exists(_imagePath))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path.GetFullPath(_imagePath), UriKind.Absolute); 
                bitmap.CacheOption = BitmapCacheOption.OnLoad; 
                bitmap.EndInit();
                StudentImage.Source = bitmap;
            }
            else
            {
                StudentImage.Source = null; 
            }
        }



        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

