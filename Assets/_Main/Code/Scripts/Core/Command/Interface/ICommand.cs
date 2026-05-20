public interface ICommand 
{
    public void Execute(object parameter);
    public bool CanExecute(object parameter);
}
