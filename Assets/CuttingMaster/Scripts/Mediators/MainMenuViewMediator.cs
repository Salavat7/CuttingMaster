using System;
using UnityEditor;
using Zenject;

public class MainMenuViewMediator : IDisposable
{
    private readonly MainMenuView _mainMenuView;
    private readonly SettingsView _settingsView;
    private readonly Slicer _slicer;
    private readonly ItemSpawner _itemSpawner;

    [Inject]
    public MainMenuViewMediator(MainMenuView mainMenuView, Slicer slicer, ItemSpawner itemSpawner, SettingsView settingsView)
    {
        _mainMenuView = mainMenuView;
        _settingsView = settingsView;
        _slicer = slicer;
        _itemSpawner = itemSpawner;

        _mainMenuView.PlayButtonPressed.AddListener(OnPlayButtonPressed);
        _mainMenuView.SettingsButtonPressed.AddListener(OnSettingsButtonPressed);
        _mainMenuView.ExitButtonPressed.AddListener(OnExitButtonPressed);

        _mainMenuView.Open();
        _slicer.gameObject.SetActive(false);
    }

    public void Dispose()
    {
        _mainMenuView.PlayButtonPressed.RemoveListener(OnPlayButtonPressed);
        _mainMenuView.SettingsButtonPressed.RemoveListener(OnSettingsButtonPressed);
        _mainMenuView.ExitButtonPressed.RemoveListener(OnExitButtonPressed);
    }

    private void OnPlayButtonPressed()
    {
        _itemSpawner.StartSpawning();
        _slicer.gameObject.SetActive(true);
        _mainMenuView.Close();
    }

    private void OnSettingsButtonPressed()
    {
        _mainMenuView.Close();
        _settingsView.Open();
    }

    private void OnExitButtonPressed()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}