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
using Microsoft.Phone.Shell;

namespace PhoneLocalDB
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
        }
        private void newTaskAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewTaskPage.xaml", UriKind.Relative));
        }
        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                // Get a handle for the to-do item bound to the button.
                ToDoItem toDoForDelete = button.DataContext as ToDoItem;

                App.ViewModel.DeleteToDoItem(toDoForDelete);
            }

            // Put the focus back to the main page.
            this.Focus();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.ViewModel.SaveChangesToDB();
        }

        private void shellTitleApplicationBarMenuItem_Click(object sender, EventArgs e)
        {

            ShellTile TileToFind = ShellTile.ActiveTiles.First();

            StandardTileData NewTileData = new StandardTileData
            {
                Title = "Pin Title",
                BackgroundImage = new Uri(@"/Images/ShellTitle.png", UriKind.Relative),
                Count = int.Parse( "12"),
                BackTitle = "Back Title",
                BackBackgroundImage = new Uri(@"/Images/ShellTitle.png", UriKind.Relative),
                BackContent = "Content"
            };

            TileToFind.Update(NewTileData);
            MessageBox.Show("OK");
        }
    }
}