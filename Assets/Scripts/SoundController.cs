using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private Menu _menu;
    [SerializeField] private AudioSource _button1Sound;
    [SerializeField] private AudioSource _button2Sound;
    [SerializeField] private AudioSource _button3Sound;

    private const string MasterVolume = "MasterVolume";
    private const string ButtonsVolume = "ButtonsVolume";
    private const string BackgroundVolume = "BackgroundVolume";
    
    private float _maxValueLevel = 0f;
    private float _minValueLevel = -80f;

    void Start()
    {
        _menu.OnMuteToggleChanged += ToggleSound;
        _menu.OnMainVolumeChanged += SetMasterVolume;
        _menu.OnButtonsVolumeChanged += SetButtonsVolume;
        _menu.OnBackgroundVolumeChanged += SetBackgroundVolume;
        _menu.OnButton1Pressed += PlayButton1Sound;
        _menu.OnButton2Pressed += PlayButton2Sound;
        _menu.OnButton3Pressed += PlayButton3Sound;
    }
    
    private void OnDestroy()
    {
        _menu.OnMuteToggleChanged -= ToggleSound;
        _menu.OnMainVolumeChanged -= SetMasterVolume;
        _menu.OnButtonsVolumeChanged -= SetButtonsVolume;
        _menu.OnBackgroundVolumeChanged -= SetBackgroundVolume;
        _menu.OnButton1Pressed -= PlayButton1Sound;
        _menu.OnButton2Pressed -= PlayButton2Sound;
        _menu.OnButton3Pressed -= PlayButton3Sound;
    }
    
    private void ToggleSound(bool isEnable)
    {
        if (isEnable)
        {
            _masterMixer.audioMixer.SetFloat(MasterVolume, _maxValueLevel);
        }
        else
        {
            _masterMixer.audioMixer.SetFloat(MasterVolume, _minValueLevel);
        }
    }

    private void SetMasterVolume(float volume)
    {
        _masterMixer.audioMixer.SetFloat(MasterVolume,Mathf.Log10(volume) * 20);
    }

    private void SetButtonsVolume(float volume)
    {
        _masterMixer.audioMixer.SetFloat(ButtonsVolume,Mathf.Log10(volume) * 20);
    }
    
    private void SetBackgroundVolume(float volume)
    {
        _masterMixer.audioMixer.SetFloat(BackgroundVolume,Mathf.Log10(volume) * 20);
    }

    private void PlayButton1Sound()
    {
        _button1Sound.Play();
    }
    
    private void PlayButton2Sound()
    {
        _button2Sound.Play();
    }
    
    private void PlayButton3Sound()
    {
        _button3Sound.Play();
    }
}
