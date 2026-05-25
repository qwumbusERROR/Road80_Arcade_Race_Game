public interface IState<out TInitialized> 
{
    public TInitialized Initialized { get; }
}
