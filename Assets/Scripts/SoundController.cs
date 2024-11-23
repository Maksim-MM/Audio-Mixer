using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const string ButtonsVolume = "ButtonsVolume";
    private const string BackgroundVolume = "BackgroundVolume";
    
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private Menu _menu;
    [SerializeField] private AudioSource _firstButtonSound;
    [SerializeField] private AudioSource _secondButtonSound;
    [SerializeField] private AudioSource _thirdButtonSound;
    
    private VolumeController _volumeController;
    private ButtonSoundController _firstButtonController;
    private ButtonSoundController _secondButtonController;
    private ButtonSoundController _thirdButtonController;
    
    private float _maxValueLevel = 0f;
    private float _minValueLevel = -80f;

    private void Start()
    {
        _volumeController = new VolumeController(_masterMixer.audioMixer);
        _firstButtonController = new ButtonSoundController(_firstButtonSound);
        _secondButtonController = new ButtonSoundController(_secondButtonSound);
        _thirdButtonController = new ButtonSoundController(_thirdButtonSound);
        
        _menu.MuteToggleChanged += ToggleSound;
        _menu.MainVolumeChanged += volume => _volumeController.SetVolume(MasterVolume, volume);
        _menu.ButtonsVolumeChanged += volume => _volumeController.SetVolume(ButtonsVolume, volume);
        _menu.BackgroundVolumeChanged += volume => _volumeController.SetVolume(BackgroundVolume, volume);
        _menu.FirstButtonPressed += _firstButtonController.PlaySound;
        _menu.SecondButtonPressed += _secondButtonController.PlaySound;
        _menu.ThirdButtonPressed += _thirdButtonController.PlaySound;
    }
    
    private void OnDestroy()
    {
        _menu.MuteToggleChanged -= ToggleSound;
        _menu.FirstButtonPressed -= _firstButtonController.PlaySound;
        _menu.SecondButtonPressed -= _secondButtonController.PlaySound;
        _menu.ThirdButtonPressed -= _thirdButtonController.PlaySound;
    }
    
    private void ToggleSound(bool isEnable)
    {
        _volumeController.ToggleSound(MasterVolume, isEnable, _maxValueLevel, _minValueLevel);
    }
}
