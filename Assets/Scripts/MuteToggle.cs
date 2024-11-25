using UnityEngine;
using UnityEngine.Audio;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private string _volumeName;
    
    private float _maxValueLevel = 0f;
    private float _minValueLevel = -80f;

    public void ToggleSound(bool isEnabled)
    {
        _masterMixer.audioMixer.SetFloat(_volumeName, isEnabled ? _maxValueLevel : _minValueLevel);
    }
}
