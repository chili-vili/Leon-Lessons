namespace Lesson8LeonObserver
{
    class NumberProcessor : IObservable
    {
        EnterNumber number;
        List<IObserver> observers;

        public NumberProcessor()
        {
            observers = new List<IObserver>();
            number = new EnterNumber();
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
                observer.Update(number);
            }
        }
        public void OnNumbersEntered()
        {
            Console.WriteLine("Введите ряд чисел через пробел");
            string[] s = Console.ReadLine().Split(' ');
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i], out int k))
                number.list.Add(k);
            }
            NotifyObserver();
        }
    }
}
