using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip intro;
    [SerializeField] private AudioClip loop;
    private AudioSource audioSource; 
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MusicWaiterPlayerThing());
    }

    // Update is called once per frame
    IEnumerator MusicWaiterPlayerThing()
    {
        audioSource.clip = intro;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = loop;
        audioSource.Play();
        audioSource.loop = true;
    }
}
