using System.Security.Cryptography.X509Certificates;

namespace Delegats3

{
    delegate void Message(string message);

    class SendMessage
    {
        public void Send(string message) {
        
        Console.WriteLine(message);

        }
        public void  Message(string message)
        {
            Console.WriteLine(message);
        }
    }
    delegate void Calculate(int x, int y);

    class Calculating
    {
        public void Plus(int x, int y)
        {
            Console.WriteLine("Операция сложения x y: " + (x + y));
            

        }
        public void Minus(int x, int y)
        {
            Console.WriteLine("Операция вычитания x y: " + (x - y));
            
        }
        public void Multiplication(int x, int y)
        {
            Console.WriteLine("Операция умножения двух x y: " + (x * y));
            
        }
    }
    class PredicCalculate
    {
        public static Predicate<int> Parn()
        {
            return num => num % 2 == 0;
        }

        public static Predicate<int> Simple(int number)
        {

            return number =>
            {
                if (number <= 1) return false;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0) return false;
                }
                return true;
            };
        }
        public static Predicate<int> IsFibonacci(int number)
        {
            return number =>
            {
                if (number < 0) return false;
                int a = 0;
                int b = 1;
                while (b < number)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                return b == number || number == 0;
            };
        }

    }

    delegate bool CheckIsEven(int x); 
    internal class Program
    {
        static void Main(string[] args)
        {
            //N1
            SendMessage sendMessage = new SendMessage();
            string name = "Alex";
            Message del = sendMessage.Send;
            del(name);
            string lastname = "Smith";
            Message del2 = sendMessage.Message;
            del2(lastname);
            //N2
           
            Calculating calculating = new Calculating();
            Calculate delcalc = calculating.Plus;
            delcalc += calculating.Minus;
            delcalc += calculating.Multiplication;
            delcalc.Invoke(7, 5);

            //N3
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            Predicate<int> predicate = PredicCalculate.Parn();

            Console.WriteLine("Четные числа:");
            foreach (var num in arr)
            {
                if (predicate(num))
                {
                    Console.WriteLine(num);
                }
            }
            int number = Convert.ToInt32(Console.ReadLine());
            Predicate<int> predicate1 = PredicCalculate.Simple(number);
            if (predicate1(number))
            {
                Console.WriteLine($"простое число.");
            }
            else
            {
                Console.WriteLine($" не простое число.");
            }

            Predicate<int> isFibonacci = PredicCalculate.IsFibonacci(number);

            if (isFibonacci(number))
            {
                Console.WriteLine($"{number} - число Фибоначчи.");
            }
            else
            {
                Console.WriteLine($"{number} - не является числом Фибоначчи.");
            }
            //N4
            CheckIsEven checkIs = delegate (int value)
            {
                return value % 2 == 0;
            };
            if(checkIs(number))
            {
                Console.WriteLine($"{number} - простое число.");
            }
            else
            {
                Console.WriteLine($"{number} - не простое число.");
            }
            //N5
            
            Func<int, int> cube = x => x * x * x;
            int result = cube(3);  
            Console.WriteLine(result);

            //N6
            var odd = arr.Where(x => x % 2 != 0);

            Console.WriteLine("Непарные числа:");
            foreach (var num in odd)
            {
                Console.WriteLine(num);
            }

        }
    }
}
