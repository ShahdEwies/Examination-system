using System.Diagnostics;

namespace ExaminationSystemC42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject s = new Subject(1,"C#");

            s.CreateExam();
            char c;
            do
            {
                Console.WriteLine("Do You Want To Start The Exam (Y | N)");
            }while (!char.TryParse(Console.ReadLine(),out c));

            if (c == 'y' || c == 'Y')
            {
                Console.Clear();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                s.SubjectExam.ShowExam();
                Console.WriteLine($" Time Taken : {sw.Elapsed}");
            }
            else
            {
                Console.WriteLine("thank you !");
            }
        }
    }
}
