namespace Lesson8LeonObserver
{
    internal class Listener1 : IObserver
    {
        public void Update(object ob)
        {
            int Sum = 0;
            int[] mas = (int[])ob;
            for (int i=0; i<(mas.Length); i++)
            {
                Sum += mas[i];
            }
            Console.WriteLine(Sum);
        }
    }
}
