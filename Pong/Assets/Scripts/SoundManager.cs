using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bounce;
    static AudioSource audioScr;
    
    void Start()
    {
        audioScr = GetComponent<AudioSource>();
        bounce = Resources.Load<AudioClip>("bounce");

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bounce":
                audioScr.PlayOneShot(bounce, 0.05f);
                break;
        }
    }

}
