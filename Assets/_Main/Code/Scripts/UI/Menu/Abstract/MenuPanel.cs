using System;
using System.Threading.Tasks;
using UnityEngine;

public abstract class MenuPanel : MonoBehaviour, IInitializedController
{
    protected MenuService MenuService { get; private set; }
    public event EventHandler Initialized;

    public void Bind(MenuService menuService)
    {
        MenuService = menuService;
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
        OnShow();
    }

    public virtual void Hide()
    {
        OnHide();
        gameObject.SetActive(false);
    }

    public virtual void Dispose()
    {
        OnDisposes();
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
    protected virtual void OnInitialized() { }
    protected virtual void OnDisposes() { }
    protected virtual Task OnInitializeAsync()
    {
        OnInitialized();                    
        return Task.CompletedTask;
    }
    public virtual async Task InitializeAsync()
    {
        await OnInitializeAsync();
        Initialized?.Invoke(this, EventArgs.Empty);
    }
}
