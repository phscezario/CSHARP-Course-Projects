using System;

namespace Basic.CRUD
{
    class Program
    {
        static ItemRepository repository = new ItemRepository();

        private static int genreEntry = 0, yearEntry = 0;
        private static string titleEntry = "", descriptionEntry = "";

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListItems();
                        break;
                    case "2":
                        InsertItem();
                        break;
                    case "3":
                        UpdateItem();
                        break;
                    case "4":
                        DeleteItem();
                        break;
                    case "5":
                        ViewItem();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                        default:
                            throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you to use our application.");
            Console.ReadLine();
        }


        private static void ListItems()
        {
            Console.WriteLine("List of items");

            var list = repository.List();

            if (list.Count == 0) 
            {
                Console.WriteLine("No item registred.");
                return;
            }

            foreach (var series in list)
            {
                Console.WriteLine($"#ID {series.ReturnId()}: - {series.ReturnTitle()}" +
                                         (series.ReturnDeleted() ? " - Delected" : ""));
            }
        }

        private static void InsertItem()
        {
            Console.WriteLine("Insert new item");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            itemRegistration();

            Item newItem = new Item(Id: repository.NextId(),
                                    genre: (Genre)genreEntry,
                                    title: titleEntry,
                                    year: yearEntry,
                                    description: descriptionEntry);

            repository.Insert(newItem);
        }

        private static void UpdateItem()
        {
            var list = repository.List();

            Console.WriteLine("Enter series Id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            if (list.Count == 0 || seriesIndex >= list.Count) 
            {
                Console.WriteLine("No item registred.");
                return;
            }

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            itemRegistration();

            Item updateSeries = new Item(Id: seriesIndex,
                                         genre: (Genre)genreEntry,
                                         title: titleEntry,
                                         year: yearEntry,
                                         description: descriptionEntry);

            repository.Update(seriesIndex, updateSeries);
        }

        private static void DeleteItem()
        {
            var list = repository.List();

            Console.WriteLine("Enter item Id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            if (list.Count == 0 || seriesIndex >= list.Count) 
            {
                Console.WriteLine("No item registred.");
                return;
            }

            Console.WriteLine("Do you really want to delete this item? Y or N");
            string confirmation = Console.ReadLine().ToUpper();

            if (confirmation == "Y")         
                repository.Delete(seriesIndex);
        }

        private static void ViewItem() 
        {
            var list = repository.List();

            Console.WriteLine("Enter item Id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            if (list.Count == 0 || seriesIndex >= list.Count) 
            {
                Console.WriteLine("No item registred.");
                return;
            }

            var series = repository.ReturnToId(seriesIndex);

            Console.WriteLine(series);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Basic CRUD Study");
            Console.WriteLine("Enter you choice:");

            Console.WriteLine();
            Console.WriteLine("Enter the new choice:");
            Console.WriteLine("1- List items");
            Console.WriteLine("2- Insert new item");
            Console.WriteLine("3- Update item");
            Console.WriteLine("4- Delete item");
            Console.WriteLine("5- View item detail");
            Console.WriteLine("C- Screen clear");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void itemRegistration()
        {
            Console.Write("Enter one of genres above: ");
            genreEntry = int.Parse(Console.ReadLine());

            Console.Write("Enter the item title: ");
            titleEntry = Console.ReadLine();

            Console.Write("Enter the release year of the item: ");
            yearEntry = int.Parse(Console.ReadLine());

            Console.Write("Enter the item description: ");
            descriptionEntry = Console.ReadLine();
        }
    }
}
