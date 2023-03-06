using System;

namespace Modul9Task2
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            NumberReader NumbReadDel = new NumberReader();
            NumbReadDel.SorterEvent += SurnameSorter;
            try
            {
                NumbReadDel.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }
        static void SurnameSorter(int number)
        {
            string[] surnames = new string[5];
            Console.WriteLine("Введите фамилии");
            for (int i = 0; i < surnames.Length; i++)
            {
                surnames[i] = Console.ReadLine();
            }
            Console.WriteLine("_______________________________________________");
            switch (number)
            {
                case 1:
                    Array.Sort(surnames);
                    break;
                case 2:
                    Array.Sort(surnames);
                    for (int i = 0, j = surnames.Length - 1; i < surnames.Length / 2; i++, j--)
                    {
                        string temp = surnames[i];
                        surnames[i] = surnames[j];
                        surnames[j] = temp;
                    }
                    break;
            }
            foreach (var item in surnames)
            {
                Console.WriteLine(item);
            }
        }
    }
    class NumberReader
    {
        public delegate void SorterDelegate(int number);
        public event SorterDelegate SorterEvent;
        public void Read()
        {
            Console.WriteLine("Необходимо ввести значение:\n1 - чтобы отсортировать массив фамилий от А до Я\n2 - чтобы отсортировать массив фамилий от Я до А");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2)
            {
                throw new MyException();
            }
            NumberEnterd(number);
        }
        protected virtual void NumberEnterd(int number)
        {
            SorterEvent?.Invoke(number);
        }

    }
    class MyException : Exception
    {
        public override string Message
        {
            get
            {
                return "Вы ввели некорректное значение.\nНажмите любую клавишу и повторите запуск программы, передав программе значение 1 или 2.";
            }
        }
    }
}