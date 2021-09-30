public interface IObserver 
{
    void Notify(string action, float life, float maxLife);
}
