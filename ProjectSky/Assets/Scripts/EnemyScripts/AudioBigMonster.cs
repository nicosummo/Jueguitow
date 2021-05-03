using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBigMonster : MonoBehaviour
{
    public static AudioClip bigMonsterDeathSound;
    static AudioSource audioSource;

    private void Start()
    {
        bigMonsterDeathSound = Resources.Load<AudioClip>("BigMonsterDeath");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "BigMonsterDeath":
                audioSource.PlayOneShot(bigMonsterDeathSound);
                break;
        }
    }
}
