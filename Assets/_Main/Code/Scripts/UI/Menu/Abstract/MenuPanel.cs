using UnityEngine;

public abstract class MenuPanel : MonoBehaviour
{
    protected MenuService MenuService { get; private set; }
    public void Bind(MenuService menuService)
    {
        MenuService = menuService;
    }

    public void Initialized()
    {
        OnInitialized();
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
}
