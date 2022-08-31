using System;

namespace Lesson8LeonObserver
{
    class NumberProcessor : IOBservable
    {
        List<IObserver> observers;
        private object numbers;

        public NumberProcessor()
        {
            observers = new List<IObserver>();
        }
        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObserver()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(numbers);
            }
        }
        public void OnNumbersEntered()
        {
            Console.WriteLine("Введите ряд чисел через пробел");
            Array numbers = (Array)Console.ReadLine().Split().Select(int.Parse);
            NotifyObserver();
        }
    }
}
