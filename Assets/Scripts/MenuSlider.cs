using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private string _volumeName;

    private void Start()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }
    
    private void SetVolume(float volume)
    {
        _masterMixer.audioMixer.SetFloat( _volumeName,Mathf.Log10(volume) * 20);
    }
}
