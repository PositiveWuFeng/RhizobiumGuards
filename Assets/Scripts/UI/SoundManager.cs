using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    public AudioSource audioSource;
    [SerializeField] private AudioClip attackAudio;
    [SerializeField] private AudioClip clickAudio;
    [SerializeField] private AudioClip victoryAudio;
    [SerializeField] private AudioClip defeatedAudio;


    private void Awake ()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject); return;
        }
        else
        {
            _instance = this;
        }
    }

    public void AttackAudio()
    {
        audioSource.clip = attackAudio;
        audioSource.Play();
    }

    public void ClickAudio()
    {
        audioSource.clip = clickAudio;
        audioSource.Play();
    }

    public void VictoryAudio()
    {
        audioSource.clip = victoryAudio;
        audioSource.Play();
    }

    public void DefeatedAudio()
    {
        audioSource.clip = defeatedAudio;
        audioSource.Play();
    }
}
