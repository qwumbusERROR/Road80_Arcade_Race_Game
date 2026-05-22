using UnityEngine;

public abstract class MenuPanel : MonoBehaviour
{
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
