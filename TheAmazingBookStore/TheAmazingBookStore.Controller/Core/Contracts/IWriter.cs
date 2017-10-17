namespace TheAmazingBookStore.Controller.Core.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
