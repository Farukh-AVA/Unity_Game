using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip shootSound; 
    private AudioSource src; 
    
    
    void Start()
    {
        src = GetComponent<AudioSource>(); 
        
    }



    // Update is called once per frame

    public void PlaySound(){
        src.PlayOneShot(shootSound); 

    }
  
}
