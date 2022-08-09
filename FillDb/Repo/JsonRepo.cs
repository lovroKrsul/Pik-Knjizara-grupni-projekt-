using Newtonsoft.Json;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillDb.Repo
{
    public class JsonRepo
    {
        private string DIR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private string PATH;

        private T GetData<T>(string source)
        {
            StreamReader reader = new StreamReader(source);
            string json = reader.ReadToEnd().ToString();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public IList<Book> LoadBooks()
        {
            PATH = DIR + @"\pika.json";
            string[] lines = File.ReadAllLines(PATH);
            
            //IList<Book> books = new List<Book>();
            IList<string> books = new List<string>();

            lines.ToList().ForEach(Console.WriteLine);

            for (int i = 0; i < lines.Length; i++)
            {

            }
            
            //books = GetData<IList<Book>>(PATH);
            return new List<Book>();
        }
    }
}
