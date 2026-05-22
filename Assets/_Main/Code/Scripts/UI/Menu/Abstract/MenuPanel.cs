using UnityEngine;

public abstract class MenuPanel : MonoBehaviour
{
    protected MenuService MenuService { get; private set; }
    
    public void Bind(MenuService menuService)
    {
        MenuService = menuService;
    }

    public virtual void Initialize() { }

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
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
