using UnityEngine;
using UnityEngine.Audio;

public class VolumeController
{
    private readonly AudioMixer _audioMixer;

    public VolumeController(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public void SetVolume(string mixerName, float volume)
    {
        _audioMixer.SetFloat(mixerName, Mathf.Log10(volume) * 20);
    }

    public void ToggleSound(string mixerName, bool isEnabled, float maxValue, float minValue)
    {
        _audioMixer.SetFloat(mixerName, isEnabled ? maxValue : minValue);
    }
}
