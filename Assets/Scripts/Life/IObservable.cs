public interface IObservable 
{
    void Subscribe(IObserver obs);   
    void Unsubscribe(IObserver obs);
    void NotifyToObservers(float life, float maxLife);
}
