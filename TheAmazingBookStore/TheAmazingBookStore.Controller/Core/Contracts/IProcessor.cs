namespace TheAmazingBookStore.Controller.Core.Contracts
{
    public interface IProcessor
    {
        void ProcessCommand(string commandAsString);
    }
}
