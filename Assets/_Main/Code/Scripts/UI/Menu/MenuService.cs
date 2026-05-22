using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class MenuService : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenuPrefab;
    [SerializeField] private SettingsMenu _settingsMenuPrefab;

    [SerializeField] private Transform _root;

    private Dictionary<Type, Pool<MenuPanel>> _poolsMenu = new();
    private MenuPanel _currentPanel;

    public void Initialize()
    {
        _poolsMenu[typeof(MainMenu)] = new Pool<MenuPanel>(_mainMenuPrefab, 1, _root);
        _poolsMenu[typeof(SettingsMenu)] = new Pool<MenuPanel>(_settingsMenuPrefab, 1, _root);

        ShowPanel<MainMenu>();
    }

    public T ShowPanel<T>() where T : MenuPanel
    {
        if (_currentPanel != null && _currentPanel.GetType() == typeof(T))
            return (T)_currentPanel;

        if (_currentPanel != null)
            HideCurrentPanel();

        T panel = GetPanel<T>();

        if (panel != null)
        {
            panel.Bind(this);
            panel.Initialize();   
            panel.Show();
            _currentPanel = panel;
        }

        return panel;
    }

    private T GetPanel<T>() where T : MenuPanel
    {
        if (!_poolsMenu.TryGetValue(typeof(T), out var pool))
        {
            return null;
        }

        return (T)pool.Get();
    }
    private void HideCurrentPanel()
    {
        _currentPanel.Hide();

        if (_poolsMenu.TryGetValue(_currentPanel.GetType(), out var pool))
            pool.Release(_currentPanel);

        _currentPanel = null;
    }
}
