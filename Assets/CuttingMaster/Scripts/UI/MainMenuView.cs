using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : ScreenView
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    public UnityEvent PlayButtonPressed => _playButton.onClick;
    public UnityEvent SettingsButtonPressed => _settingsButton.onClick;
    public UnityEvent ExitButtonPressed => _exitButton.onClick;

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }
}
