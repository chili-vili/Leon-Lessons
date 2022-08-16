
namespace Lesson4Leon
{
    public record CachedValue<T>
    {
        public T? Value { get; set; }
        public DateTime CreationTime { get; set; }
        public int Timeout { get; set; }
    }
}
