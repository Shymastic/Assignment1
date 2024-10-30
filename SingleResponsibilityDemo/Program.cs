using Newtonsoft.Json;
using SingleResponsabilityPrinciple.Model;
using SingleResponsibilityDemo.Ultilities;
namespace SingleResponsibilityDemo
{
    public class Program
    {
        static List<Book> bookList;
        static void PrintBooks(List<Book> books)
        {
            Console.WriteLine("List of Books ");
            Console.WriteLine("--------------------------");
            /*            var cadJSON = File.ReadAllText("Data/BookStore.json");
                        var bookList = JsonConvert.DeserializeObject<Book[]>(cadJSON);*/
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Title.PadRight(39, ' ')}" +
                    $"{item.Author.PadRight(20, ' ')} {item.Price}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please, press 'yes' to read an extra file");
            Console.WriteLine("or any other key for a single file");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes") ? Ultilities.Ultilities.ReadData() : Ultilities.Ultilities.ReadExtraData();
            PrintBooks(bookList);
            /*            Console.WriteLine("List of Books ");
                        Console.WriteLine("--------------------------");
                        *//*            var cadJSON = File.ReadAllText("Data/BookStore.json");
                                    var bookList = JsonConvert.DeserializeObject<Book[]>(cadJSON);*//*
                        var bookList = Ultilities.Ultilities.ReadData();
                        foreach (var item in bookList)
                        {
                            Console.WriteLine($"{item.Title.PadRight(39, ' ')}" +
                                $"{item.Author.PadRight(15, ' ')} {item.Price}");
                        }*/
        }
    }
}
