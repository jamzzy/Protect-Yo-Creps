using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource aS;
    public AudioSource soundEffects;
    public AudioClip menu;
    public AudioClip shopcloset;
    public AudioClip selects;
    public AudioClip level1;
    public AudioClip[] various = new AudioClip[7];
    public System.Random rnd = new System.Random();
    public int phrase = 0;
    public bool level;
    // Start is called before the first frame update
    void Start()
    {
        if (!level)
        {
            aS.clip = menu;
        }
        else
            aS.clip = level1;
       
        aS.Play();
    }

    // Update is called once per frame
    public void ShopMusic()
    {
        aS.clip = shopcloset;
        aS.Play();
    }
    public void MenuMusic()
    {
        aS.clip = menu;
        aS.Play();
    }
    public void SelectMusic()
    {
        aS.clip = selects;
        aS.Play();
    }
    public void VariousSounds()
    {
        phrase = rnd.Next(0, 5);
        //Debug.Log(phrase);
        soundEffects.clip = various[phrase];
        soundEffects.Play();
    }
    public void Fault()
    {
        aS.Stop();
        soundEffects.clip = various[6];
        soundEffects.Play();
    }
    public void Jheez()
    {
        aS.Stop();
        soundEffects.clip = various[5];
        soundEffects.Play();
    }
}
