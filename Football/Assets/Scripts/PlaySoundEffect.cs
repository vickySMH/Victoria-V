using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public AudioClip soundEffect;
    public AudioSource audioSource;
    public bool playOnStart = false;

    private void Start()
    {
        if (playOnStart)
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}