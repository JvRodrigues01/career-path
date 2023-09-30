using Bogus;

namespace Tests
{
    public class ObjectFaker<T> : Faker<T> where T : class
    {
        public ObjectFaker<T> UsePrivateConstructor()
            => base.CustomInstantiator(f => Activator.CreateInstance(typeof(T), true) as T) as ObjectFaker<T>;
    }
}
