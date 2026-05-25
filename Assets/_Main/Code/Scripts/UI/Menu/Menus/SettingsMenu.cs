using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MenuPanel
{
    [SerializeField] private Button _backButton;
    protected override void OnInitialized()
    {
        _backButton?.onClick.AddListener(OnBackClicked);
    }

    protected override void OnShow()
    {
        
    }

    protected override void OnHide()
    {
        
    }
    protected override void OnDisposes()
    {
        _backButton?.onClick.RemoveListener(OnBackClicked);
    }
    private async void OnBackClicked()
    {
        await MenuService.ShowPanel<MainMenu>();
    }
}
