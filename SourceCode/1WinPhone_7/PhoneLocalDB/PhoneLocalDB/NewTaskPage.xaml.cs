using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PhoneLocalDB.Model;
using PhoneLocalDB.Common;

namespace PhoneLocalDB
{
    public partial class NewTaskPage : PhoneApplicationPage
    {
        public NewTaskPage()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
        }
        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            // Confirm there is some text in the text box.
            if (newTaskNameTextBox.Text.Length > 0)
            {
                // Create a new to-do item.
                ToDoItem newToDoItem = new ToDoItem
                {
                    ItemName = newTaskNameTextBox.Text
                };

                // Add the item to the ViewModel.
                App.ViewModel.AddToDoItem(newToDoItem);

                MessageBoxResult msgBoxresult = MessageBox.Show("Add Finished", "Information", MessageBoxButton.OK);
                if (msgBoxresult == MessageBoxResult.OK)
                {
                    // Return to the main page.
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.GoBack();
                    }
                }
                //NavigationService.Navigate(new Uri(@"/MainPage.xaml", UriKind.Relative));
            }
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}