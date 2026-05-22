using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MenuPanel
{
    [SerializeField] private Button _backButton;

    public override void Initialize()
    {
        Debug.Log("Initialized SettingsMenu");

        _backButton.onClick.AddListener(OnBackClicked);
    }

    protected override void OnShow()
    {

    }

    protected override void OnHide()
    {

    }

    private void OnBackClicked()
    {
        MenuService.ShowPanel<MainMenu>();
    }
}
