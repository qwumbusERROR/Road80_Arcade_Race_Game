using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuPanel
{
    [SerializeField] private Button _settingsButton;

    public override void Initialize()
    {
        Debug.Log("Initialized MainMenu");

        _settingsButton.onClick.AddListener(OnSettingsClicked);
    }

    protected override void OnShow()
    {

    }

    protected override void OnHide()
    {
        
    }

    private void OnSettingsClicked()
    {
        MenuService.ShowPanel<SettingsMenu>();
    }
}
