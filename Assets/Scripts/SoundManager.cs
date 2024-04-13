using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instantiate;
    public AudioClip[] audios;
    private AudioSource audioSource;
    void Awake(){
        if(Instantiate == null){
            Instantiate = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(int soundID){
        audioSource.PlayOneShot(audios[soundID]);
    }
}
