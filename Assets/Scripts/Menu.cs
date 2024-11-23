using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Toggle _muteToggle;
    [SerializeField] private Slider _mainVolume;
    [SerializeField] private Slider _buttonVolume;
    [SerializeField] private Slider _backgroundVolume;
    [SerializeField] private Button _firstButton;
    [SerializeField] private Button _secondButton;
    [SerializeField] private Button _thirdButton;
    
    public event Action<bool> MuteToggleChanged;
    public event Action<float> MainVolumeChanged; 
    public event Action<float> ButtonsVolumeChanged;
    public event Action<float> BackgroundVolumeChanged;
    public event Action FirstButtonPressed;
    public event Action SecondButtonPressed;
    public event Action ThirdButtonPressed;
    
    private void Start()
    {
        _muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);
        _mainVolume.onValueChanged.AddListener(OnMainVolumeChanged);
        _buttonVolume.onValueChanged.AddListener(OnButtonsVolumeChanged);
        _backgroundVolume.onValueChanged.AddListener(OnBackgroundVolumeChanged);

        _firstButton.onClick.AddListener(OnFirstButtonPressed);
        _secondButton.onClick.AddListener(OnSecondButtonPressed);
        _thirdButton.onClick.AddListener(OnThirdButtonPressed);
    }

    private void OnDestroy()
    {
        _muteToggle.onValueChanged.RemoveListener(OnMuteToggleChanged);
        _mainVolume.onValueChanged.RemoveListener(OnMainVolumeChanged);
        _buttonVolume.onValueChanged.RemoveListener(OnButtonsVolumeChanged);
        _backgroundVolume.onValueChanged.RemoveListener(OnBackgroundVolumeChanged);

        _firstButton.onClick.RemoveListener(OnFirstButtonPressed);
        _secondButton.onClick.RemoveListener(OnSecondButtonPressed);
        _thirdButton.onClick.RemoveListener(OnThirdButtonPressed);
    }

    private void OnMuteToggleChanged(bool isOn) => MuteToggleChanged?.Invoke(isOn);
    
    private void OnMainVolumeChanged(float value) => MainVolumeChanged?.Invoke(value);
    
    private void OnButtonsVolumeChanged(float value) => ButtonsVolumeChanged?.Invoke(value);
    
    private void OnBackgroundVolumeChanged(float value) => BackgroundVolumeChanged?.Invoke(value);

    private void OnFirstButtonPressed() => FirstButtonPressed?.Invoke();
    
    private void OnSecondButtonPressed() => SecondButtonPressed?.Invoke();
    
    private void OnThirdButtonPressed() => ThirdButtonPressed?.Invoke();
}
