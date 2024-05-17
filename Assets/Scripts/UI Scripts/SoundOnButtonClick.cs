using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnButtonClick: MonoBehaviour
{
    [SerializeField] AudioSource normalButtonSound;
    
    public void PlayNormalButtonSound()
    {
        normalButtonSound.Play();
    }
    
}
