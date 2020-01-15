using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLiteAgain.Models;
using SQLitePCL;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteAgain
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void processSQLite(Student student)
        {
            SQLiteConnection connection = new SQLiteConnection("demo.db");
            var sqlQuerry = "insert into Students (name, age) values (?, ?)";
            var statement = connection.Prepare(sqlQuerry);
            statement.Bind(1, student.Name);
            statement.Bind(2, student.Age);
            statement.Step();

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var student = new Student()
            {
                Name = StudentName.Text,
                Age = Convert.ToInt32(StudentAge.Text)
            };
            processSQLite(student);
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListStudent));
        }
    }
}
