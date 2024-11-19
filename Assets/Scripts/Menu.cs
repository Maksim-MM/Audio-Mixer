using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Toggle _muteToggle;
    [SerializeField] private Slider _mainVolume;
    [SerializeField] private Slider _buttonVolume;
    [SerializeField] private Slider _backgroundVolume;
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    
    public event Action<bool> OnMuteToggleChanged;
    public event Action<float> OnMainVolumeChanged; 
    public event Action<float> OnButtonsVolumeChanged;
    public event Action<float> OnBackgroundVolumeChanged;
    public event Action OnButton1Pressed;
    public event Action OnButton2Pressed;
    public event Action OnButton3Pressed;
    

    void Start()
    {
        _muteToggle.onValueChanged.AddListener((isOn) => { OnMuteToggleChanged?.Invoke(isOn); });
        
        _mainVolume.onValueChanged.AddListener(value => { OnMainVolumeChanged?.Invoke(value); });
        
        _buttonVolume.onValueChanged.AddListener(value => { OnButtonsVolumeChanged?.Invoke(value); });
        
        _backgroundVolume.onValueChanged.AddListener(value => { OnBackgroundVolumeChanged?.Invoke(value); });
        
        _button1.onClick.AddListener (() => { OnButton1Pressed?.Invoke(); });
        
        _button2.onClick.AddListener (() => { OnButton2Pressed?.Invoke(); });
        
        _button3.onClick.AddListener (() => { OnButton3Pressed?.Invoke(); });
    }
}
