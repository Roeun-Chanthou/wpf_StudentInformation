using System;
using System.Collections.Generic;
using System.IO;
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

namespace StudentInformation.Pages
{
    /// <summary>
    /// Interaction logic for MyGroup.xaml
    /// </summary>
    public partial class MyGroup : UserControl
    {
        public MyGroup()
        {
            InitializeComponent();
        }
        public void LoadMyGroupData()
        {
            List<string[]> tbPeople = new List<string[]>
                {
                    new string[] { "រឿន ចាន់ធូ", "អ្នកអភិវឌ្ឈន៏", "chanthou.png" },
                    new string[] { "ពៅ មករា", "អ្នកអភិវឌ្ឈន៏", "makara.png" },
                    new string[] { "គង់ ប៊ុនលីម", "អ្នកអភិវឌ្ឈន៏", "lim.jpg" },
                    new string[] { "ធីម ប៊ុនហូវ", "អ្នកអភិវឌ្ឈន៏", "hov.jpg" },
                };

            for (int i = 0; i < tbPeople.Count; i++)
            {
                var temp = new Components.MyCard();

                temp.TextName.Text = tbPeople[i][0];
                temp.TextCourse.Text = tbPeople[i][1];

                string imagePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "MyGroup/images/", tbPeople[i][2]);
                temp.BorderAvatar.Background = new ImageBrush(new BitmapImage(new Uri(imagePath)))
                {
                    Stretch = Stretch.UniformToFill
                };

                switch (i % 4)
                {
                    case 0:
                        StackPanel1.Children.Add(temp);
                        break;
                    case 1:
                        StackPanel2.Children.Add(temp);
                        break;
                    case 2:
                        StackPanel3.Children.Add(temp);
                        break;
                    case 3:
                        StackPanel4.Children.Add(temp);
                        break;
                }
            }

        }
    }
}
