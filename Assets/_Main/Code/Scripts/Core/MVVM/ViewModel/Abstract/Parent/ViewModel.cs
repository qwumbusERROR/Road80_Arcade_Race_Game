public abstract class ViewModel<TValue> 
{
    protected ObservableModel<TValue> _currentModel;
    public ReactiveProperty<TValue> Value = new();

    public ViewModel(ObservableModel<TValue> model)
    {
        _currentModel = model;

        _currentModel.Value.Subscribe(OnModelChanged);
    }

    private void OnModelChanged(TValue amount)
    {
        Value.Value = amount;
    }

    public void Dispose()
    {
        _currentModel.Value.Unsubscribe(OnModelChanged);
    }
}
