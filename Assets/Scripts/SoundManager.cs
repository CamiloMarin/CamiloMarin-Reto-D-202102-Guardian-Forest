using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip powerShieldSound, dashSound, flySound, attackSound, deadSound, damageSound, bugSound, buttonSound;
    static AudioSource audioSrc;
    void Start()
    {
        powerShieldSound = Resources.Load<AudioClip>("shield");
        dashSound = Resources.Load<AudioClip>("dash");
        flySound = Resources.Load<AudioClip>("fly");
        attackSound = Resources.Load<AudioClip>("attack");
        deadSound = Resources.Load<AudioClip>("dead");
        damageSound= Resources.Load<AudioClip>("damage");
        bugSound = Resources.Load<AudioClip>("bug");
        buttonSound = Resources.Load<AudioClip>("on");

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

        switch (clip)
        {
            case "dash":
                audioSrc.PlayOneShot(dashSound);
                break;
        }

        switch (clip)
        {
            case "fly":
                audioSrc.PlayOneShot(flySound);
                break;
        }

        switch (clip)
        {
            case "attack":
                audioSrc.PlayOneShot(attackSound);
                break;
        }

        switch (clip)
        {
            case "dead":
                audioSrc.PlayOneShot(deadSound);
                break;
        }

        switch (clip)
        {
            case "damage":
                audioSrc.PlayOneShot(damageSound);
                break;
        }

        switch (clip)
        {
            case "bug":
                audioSrc.PlayOneShot(bugSound);
                break;
        }

        switch (clip)
        {
            case "on":
                audioSrc.PlayOneShot(buttonSound);
                break;
        }
    }
}
