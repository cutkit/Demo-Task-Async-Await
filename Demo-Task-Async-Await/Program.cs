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
        static async Task ShowLenghOfFile()//async thông báo hàm này chạy bất đồng bộ 
            //nếu gọi hàm này các câu lệnh trên await sẽ được chạy trước, gặp câu lệnh await 
            //nghĩa là sau nó có 1 task(Task này chạy mất nhiều thời gian, bắt buộc là 1 Task)
            //Các hàm gọi nó sẽ không chờ nó chạy hết hàm (từ await trở xuống), mà sẽ chạy tiếp các câu lệnh phía
            //sau của hàm gọi
        {
            Console.WriteLine("Start ShowLenghOfFile");
            int lengh = await ReadFile();//s Từ khóa await cho phép chờ đợi kết quả để thực hiện các câu lệnh phía sau nó
            //và ở đâu gọi tới hàm này sẽ cho phép nó chạy tiếp các câu lệnh phía sau mà không phải chờ hàm này thực hiện xong
            //
            Console.WriteLine("End ShowLenghOfFile \n" + lengh);
        }
        static void Call()
        {
            ShowLenghOfFile();
            Console.WriteLine("End Method Call");
        }
        //
        static void Main(string[] args)
        {
            Call();
            Console.WriteLine("End Method Main");
            Console.ReadKey();
        }
    }
}
