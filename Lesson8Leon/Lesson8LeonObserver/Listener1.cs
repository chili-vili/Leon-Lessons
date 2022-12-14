using System;

namespace Lesson8LeonObserver
{
    internal class Listener1 : IObserver
    {
        IObservable numberProcessor;
  
        public Listener1(IObservable numberProcessor1)
        {
            numberProcessor = numberProcessor1;
            numberProcessor.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            EnterNumber number = (EnterNumber)ob;
            Console.WriteLine(number.list.Sum());
        }
    }
}
