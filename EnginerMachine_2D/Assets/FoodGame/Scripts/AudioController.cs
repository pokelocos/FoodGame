using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioListener lisener;
    public AudioSource musicSource;
    public AudioSource hudSource;


    private static AudioController instance;

    private void Awake()
    {
        if(instance == null){
            instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }

        
    }

    public bool Mute
    {
        set
        {
            lisener.gameObject.SetActive(value);
        }
    }

    public void PlaySound(AudioClip ac)
    {
        hudSource.PlayOneShot(ac);
    }
}
