using System;
using System.Threading.Tasks;
public interface IInitializedController 
{
    public event EventHandler Initialized;
    public Task InitializeAsync();
}
