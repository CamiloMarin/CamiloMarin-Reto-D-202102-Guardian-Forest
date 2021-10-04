using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip powerShieldSound;
    static AudioSource audioSrc;
    void Start()
    {
        powerShieldSound = Resources.Load<AudioClip>("shield");

        audioSrc = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    public static void Playsound (string clip)
    {
        switch (clip)
        {
            case "shield":
                audioSrc.PlayOneShot(powerShieldSound);
                break;
        }
    }
}
