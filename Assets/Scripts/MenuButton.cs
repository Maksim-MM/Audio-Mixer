using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonSound;
    
    public void PlaySound()
    {
        _buttonSound.Play();
    }
}
