using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExercise
{
    public class Client
    {
        private readonly Server mServer;

        public Client(Server server)
        {
            mServer = server;
        }

        public void run()
        {
            while (true)
            {
                int number = GetNumber("Enter a number (0 for stop): ");

                if (number == 0) break;

                int[] numbers = mServer.GetNumbers(number, 1, 6);

                //_ = Task.Factory.StartNew(() => {
                //    int[] numbers = mServer.GetNumbers(number, 1, 6);
                //    WriteToFile(numbers);
                //});


            }
        }

        private int GetNumber(String text)
        {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }

        private void WriteToFile(int[] numbers)
        {
            string path = @"fromclient.txt";

            StringBuilder sb = new StringBuilder();

            foreach (var x in numbers)
                sb.Append(x.ToString() + ", ");

            sb.Remove(sb.Length - 2, 2);

            StreamWriter sw = File.AppendText(path);

            sw.WriteLine(sb.ToString());

            sw.Flush();
        }

    }
}
