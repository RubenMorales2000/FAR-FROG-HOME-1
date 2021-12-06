using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour
{
    public static AudioClip playerJumpSound1, playerCollision, playerDeath;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerDeath = Resources.Load<AudioClip>("muerte");
        playerJumpSound1 = Resources.Load<AudioClip>("playerJump");
        playerCollision = Resources.Load<AudioClip>("collision");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySounds (string clip)
    {
        switch (clip)
        {
            case "playerJump":
                audioSrc.PlayOneShot(playerJumpSound1);
                break;
            case "death":
                audioSrc.PlayOneShot(playerDeath);
                break;
            case "collision":
                audioSrc.PlayOneShot(playerCollision);
                break;
        }
    }
}
