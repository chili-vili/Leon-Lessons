namespace Lesson8LeonObserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberProcessor numberProcessor = new NumberProcessor();
            Listener1 listener1 = new Listener1(numberProcessor);
            Listener2 listener2 = new Listener2(numberProcessor);
            numberProcessor.OnNumbersEntered();
            Console.Read();
        }
    }
}