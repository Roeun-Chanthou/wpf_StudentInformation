using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StudentInformation.Pages
{
    public partial class StudentDataPage : UserControl
    {
        public StudentDataPage()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            GridDisplay.Children.Clear();

            if (!File.Exists("Data/Student.txt"))
            {
                return;
            }

            using (StreamReader reader = new StreamReader("Data/Student.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arrData = line.Split(';');

               
                    Components.Data studentCard = new Components.Data
                    {
                        TextBlockID = { Text = arrData[0] },
                        TextBlockName = { Text = arrData[1] },
                        TextBlockGender = { Text = arrData[2] },
                        TextBlockMajor = { Text = arrData[3] },
                        TextBlockPhone = { Text = arrData[4] },
                        ImagePath = arrData[5] 
                    };

        
                    GridDisplay.Children.Add(studentCard);
                }
            }
        }



    }
}

