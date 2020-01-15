using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SQLiteAgain
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListStudent : Page
    {
        public ListStudent()
        {
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ListStudent_OnLoaded(object sender, RoutedEventArgs e)
        {
            var sqlConnection = new SQLiteConnection("demo.db");
            var sqlString = "select * from Students";
            var statement = sqlConnection.Prepare(sqlString);

            while (statement.Step() == SQLiteResult.ROW)
            {
                var name1 = statement[1];
                MyListStudent.Items.Add(name1);
            }
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            MyListStudent.Items.Clear();
           var keyword = SearchString.Text;
           var sqlConnection = new SQLiteConnection("demo.db");
           var sqlString = "select * from Students where name like ?";
           var statement = sqlConnection.Prepare(sqlString);
           statement.Bind(1, $"%{keyword}%");
           if (statement.Step() == SQLiteResult.ROW)
           {
               var name1 = statement[1];
               MyListStudent.Items.Add(name1);
           }
        }
    }
}
