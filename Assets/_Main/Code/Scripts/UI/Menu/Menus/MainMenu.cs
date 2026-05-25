using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuPanel
{
    [SerializeField] private Button _settingsButton;
    protected override void OnInitialized()
    {
        _settingsButton?.onClick.AddListener(OnSettingsClicked);
    }

    protected override void OnShow()
    {
        
    }

    protected override void OnHide()
    {
       
    }

    protected override void OnDisposes()
    {
        _settingsButton?.onClick.RemoveListener(OnSettingsClicked);
    }

    private async void OnSettingsClicked()
    {
        await MenuService.ShowPanel<SettingsMenu>();
    }
}
