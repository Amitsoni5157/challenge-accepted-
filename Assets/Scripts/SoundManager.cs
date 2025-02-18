using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip flipSound; 
    public AudioClip matchSound; 
    public AudioClip mismatchSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
            instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    
    public void PlayFlipSound()
    {
        audioSource.PlayOneShot(flipSound);
    }

   
    public void PlayMatchSound()
    {
        audioSource.PlayOneShot(matchSound);
    }

   
    public void PlayMismatchSound()
    {
        audioSource.PlayOneShot(mismatchSound);
    }

}
