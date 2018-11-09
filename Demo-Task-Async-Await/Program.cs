using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task_Async_Await
{
    class Program
    {
        static Task<int> ReadFile()// Tạo ra 1 Task, và chạy nó rồi trả ra 1 Task, Task đó phả start
        {
            Task<int> result = new Task<int>(() => File.ReadAllBytes(@"D:\bin.txt").Length);
            result.Start();//Chạy task, không chạy nó sẽ không có kết quả trả về
            return result;
        }
        static async Task ShowLenghOfFile()
        {
            Console.WriteLine("Start 1");
            int lengh = await ReadFile();
            Console.WriteLine("Start 3 \n"+ lengh);
        }
        static async Task CallTaskAsync()
        {
            await ShowLenghOfFile();
        }
        static void Main(string[] args)
        {
            ShowLenghOfFile();
            Console.WriteLine("Start 2");
            Console.ReadKey();
        }
    }
}
