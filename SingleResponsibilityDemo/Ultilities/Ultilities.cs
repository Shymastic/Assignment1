using Newtonsoft.Json;
using SingleResponsabilityPrinciple.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityDemo.Ultilities
{
    public class Ultilities
    {
        static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
        internal static List<Book> ReadData()
        {
            var cadJSON = ReadFile("D:\\PRN221_TrialTest\\PRN221PE_FA22_TrialTest_LeNguyenDangKhoa\\SingleResponsibilityDemo\\Data\\BookStore_01.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
        }
        internal static List<Book> ReadExtraData()
        {
            {
                List<Book> books = ReadData();
                var cadJSON = ReadFile("D:\\PRN221_TrialTest\\PRN221PE_FA22_TrialTest_LeNguyenDangKhoa\\SingleResponsibilityDemo\\Data\\BookStore_01.json");
                books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
                return books;
            }
        }
        internal static List<Book> ReadData(string extra)
        {
            List<Book> books = ReadData();
            var filename = "Data/BookStore_02.json";
                var cadJSON = ReadFile(filename);
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            if(extra == "topic")
            {
                filename = "Data/BookStore_03.json";
                cadJSON = ReadFile(filename);
                books.AddRange(JsonConvert.DeserializeObject<List<TopicBook>>(cadJSON));
            }
            return books;
        }
    }
}
