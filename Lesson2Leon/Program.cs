
using System;

namespace Lesson2Leon
{
    class Program
    {
        public static void Main(string[] args)
        {
            int count;
            Console.WriteLine("Введите количество респондентов: ");
            while (!int.TryParse(Console.ReadLine(), out count))
            { Console.WriteLine("Ввод не верный! Повторите еще раз!"); }

            List<Responder> responder = new List<Responder>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите имя: ");
                string name = Console.ReadLine();

                Console.WriteLine("Введите фамилию: ");
                string surname = Console.ReadLine();

                Console.WriteLine("Введите возраст: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age))
                { Console.WriteLine("Ввод не верный! Повторите еще раз!"); }

                Console.WriteLine("Введите ваше увлечение: ");
                string hobby = Console.ReadLine();
                responder.Add(new Responder(name, surname, age, hobby));
            }

            Print(responder);

            Console.WriteLine("Программа завершена! Нажмите Enter для выхода...");
            Console.ReadLine();
        }
        static void Print(List<Responder> responder)
        {
            foreach (var resp in responder)
            {
                Console.WriteLine($"Name: {resp.Name}\nSurname: {resp.Surname}\nAge: {resp.Age}\nHobby: {resp.Hobby}\n");
            }
        }
    }

    public class Responder
    {
        public Responder(string? name, string? surname, int age, string? hobby)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Hobby = hobby;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Hobby { get; set; }

    }


}
