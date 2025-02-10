using System;
using Zenject;

public class SettingsViewMediator : IDisposable
{
    private readonly SettingsView _settingsView;
    private readonly MainMenuView _mainMenuView;

    [Inject]
    public SettingsViewMediator(SettingsView settingsView, MainMenuView mainMenuView)
    {
        _settingsView = settingsView;
        _mainMenuView = mainMenuView;

        _settingsView.ExitButtonPressed.AddListener(OnExitButtonPressed);
    }

    public void Dispose()
    {
        _settingsView.ExitButtonPressed.RemoveListener(OnExitButtonPressed);
    }

    private void OnExitButtonPressed()
    {
        _settingsView.Close();
        _mainMenuView.Open();
    }
}
