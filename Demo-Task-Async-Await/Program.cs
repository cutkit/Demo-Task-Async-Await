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
        static Task<int> ReadFile()// Tạo ra 1 Task, và chạy nó rồi trả ra 1 Task, Task đó phải start
        {
            Task<int> result = new Task<int>(() => File.ReadAllBytes(@"D:\bin.txt").Length);
            //Sử dụng lệnh bên dưới để chạy task
            //Task<int> result = Task<int>.Run(() => File.ReadAllBytes(@"D:\bin.txt").Length);
            result.Start();//Chạy task, không chạy nó sẽ không có kết quả trả về
           
            return result;
        }
        static async Task ShowLenghOfFile()
        {
            Console.WriteLine("Start 1");
            int lengh = await ReadFile();//s Từ khóa await cho phép chờ đợi kết quả để thực hiện các câu lệnh phía sau nó
            //và ở đâu gọi tới hàm này sẽ cho phép nó chạy tiếp các câu lệnh phía sau mà không phải chờ hàm này thực hiện xong
            //
            Console.WriteLine("Start 3 \n"+ lengh);
        }
        static async Task CallTaskAsync()
        {
            await ShowLenghOfFile();
        }
        //
        static void Main(string[] args)
        {
            ShowLenghOfFile();
            Console.WriteLine("Start 2");
            Console.ReadKey();
        }
    }
}
