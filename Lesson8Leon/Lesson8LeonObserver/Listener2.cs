namespace Lesson8LeonObserver
{
    internal class Listener2 : IObserver
    {
        IObservable numberProcessor;

        public Listener2(IObservable numberProcessor1)
        {
            numberProcessor = numberProcessor1;
            numberProcessor.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            EnterNumber number = (EnterNumber)ob;
            number.list.Reverse();
            foreach (var numb in number.list) Console.Write(numb+" ");
        }
    }
}
