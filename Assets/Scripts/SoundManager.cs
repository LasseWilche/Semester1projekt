using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum SoundType
{
    GLOORPSHOTSHOUND,
    SWORDSWINGSOUND1,
    SWORDSWINGSOUND2,
    SWORDSWINGSOUND3,
    HURTINGSOUND1,




}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundlist;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public static void PlaySound(SoundType sound, float volume = 1) 
    {
        instance.audioSource.PlayOneShot(instance.soundlist[(int)sound],volume);
    }



}
