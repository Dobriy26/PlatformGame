namespace CityBuilder.Scripts.Interface
{
    public interface ISaveService
    {
        void Write(object obj, string name);
        T Load<T>(string name);
        void Save ();
    }
}