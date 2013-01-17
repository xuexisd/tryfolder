using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

// Directive for the data model.
using PhoneLocalDB.Model;
using PhoneLocalDB.Common;


namespace PhoneLocalDB.ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private ToDoDataContext Context;

        // Class constructor, create the data context object.
        public ToDoViewModel(string toDoDBConnectionString)
        {
            Context = new ToDoDataContext(toDoDBConnectionString);
        }

        //
        // TODO: Add collections, list, and methods here.
        //

        // All to-do items.
        private ObservableCollection<ToDoItem> _allToDoItems;
        public ObservableCollection<ToDoItem> AllToDoItems
        {
            get { return _allToDoItems; }
            set
            {
                _allToDoItems = value;
                NotifyPropertyChanged("AllToDoItems");
            }
        }
        // To-do items associated with the home category.
        private ObservableCollection<ToDoItem> _homeToDoItems;
        public ObservableCollection<ToDoItem> HomeToDoItems
        {
            get { return _homeToDoItems; }
            set
            {
                _homeToDoItems = value;
                NotifyPropertyChanged("HomeToDoItems");
            }
        }

        // To-do items associated with the work category.
        private ObservableCollection<ToDoItem> _workToDoItems;
        public ObservableCollection<ToDoItem> WorkToDoItems
        {
            get { return _workToDoItems; }
            set
            {
                _workToDoItems = value;
                NotifyPropertyChanged("WorkToDoItems");
            }
        }

        // To-do items associated with the hobbies category.
        private ObservableCollection<ToDoItem> _hobbiesToDoItems;
        public ObservableCollection<ToDoItem> HobbiesToDoItems
        {
            get { return _hobbiesToDoItems; }
            set
            {
                _hobbiesToDoItems = value;
                NotifyPropertyChanged("HobbiesToDoItems");
            }
        }

        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            Context.SubmitChanges();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        #region function
        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {

            // Specify the query for all to-do items in the database.
            //var toDoItemsInDB = from ToDoItem todo in toDoDB.Items
            //                    select todo;
            var allData = from all in Context.AllItems
                          select all;
            var homeData = from all in Context.AllItems
                          where all.ItemName.Contains("BB")
                          select all;
            var workData = from all in Context.AllItems
                          where all.ItemName.Contains("CC")
                          select all;
            var hobbiesData = from all in Context.AllItems
                          where all.ItemName.Contains("DD")
                          select all;

            // Query the database and load all to-do items.
            AllToDoItems = new ObservableCollection<ToDoItem>(allData);
            // "Home":
            HomeToDoItems = new ObservableCollection<ToDoItem>(homeData);
            //"Work":
            WorkToDoItems = new ObservableCollection<ToDoItem>(workData);
            //"Hobbies":
            HobbiesToDoItems = new ObservableCollection<ToDoItem>(hobbiesData);
        }
        // Add a to-do item to the database and collections.
        public void AddToDoItem(ToDoItem newToDoItem)
        {
            // Add a to-do item to the data context.
            Context.AllItems.InsertOnSubmit(newToDoItem);

            // Save changes to the database.
            Context.SubmitChanges();

            // Add a to-do item to the appropriate filtered collection.
            AllToDoItems.Add(newToDoItem);
            switch (newToDoItem.ItemName.Substring(0,2))
            {
                case "BB":
                    HomeToDoItems.Add(newToDoItem);
                    break;
                case "CC":
                    WorkToDoItems.Add(newToDoItem);
                    break;
                case "DD":
                    HobbiesToDoItems.Add(newToDoItem);
                    break;
                default:
                    break;
            }
        }
        // Remove a to-do task item from the database and collections.
        public void DeleteToDoItem(ToDoItem toDoForDelete)
        {
            // Remove the to-do item from the data context.
            Context.AllItems.DeleteOnSubmit(toDoForDelete);


            // Save changes to the database.
            Context.SubmitChanges();


            AllToDoItems.Remove(toDoForDelete);
            switch (toDoForDelete.ItemName.Substring(0, 2))
            {
                case "BB":
                    HomeToDoItems.Remove(toDoForDelete);
                    break;
                case "CC":
                    WorkToDoItems.Remove(toDoForDelete);
                    break;
                case "DD":
                    HobbiesToDoItems.Remove(toDoForDelete);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}