namespace OpenAM.Core.Providers
{
    public interface IDataProvider<out T>
    {
        T Get();
    }

    public interface IDataProvider<out TData, in TSource>
    {
        TData Get(TSource source);
    }
}
