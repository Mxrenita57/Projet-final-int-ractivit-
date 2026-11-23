using UnityEngine;

public class SonAttaque : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void JouerSonCoup()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}