using UnityEngine;

public class ButtonSoundController
{
    private readonly AudioSource _audioSource;

    public ButtonSoundController(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
