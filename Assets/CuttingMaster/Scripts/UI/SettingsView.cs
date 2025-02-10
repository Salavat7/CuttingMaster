using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsView : ScreenView
{
    [SerializeField] private Slider _soundVolume;
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Slider _difficulty;
    [SerializeField] private Button _exitButton;

    public UnityEvent<float> SoundVolumeChanged => _soundVolume.onValueChanged;
    public UnityEvent<bool> SoundToggleChanged => _soundToggle.onValueChanged;
    public UnityEvent<float> DifficultyChanged => _difficulty.onValueChanged;
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
