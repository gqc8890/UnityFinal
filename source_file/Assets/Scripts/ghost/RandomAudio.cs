using UnityEngine;
using System.Collections;

public class RandomAudio : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip otherClip1;
    public AudioClip otherClip2;
    public AudioClip otherClip3;
    public AudioClip otherClip4;
    public AudioClip otherClip5;
    public float musicVolume;
    public float randomNum;
    public int state;

    // Use this for initialization
    void Start () {
        musicVolume = 0.8f;
        randomPlay();
    }
     
     // Update is called once per frame
    void Update () {
        audioSource.volume = musicVolume;
        if ((state == 1 && !audioSource.isPlaying)||(state == 2 && !audioSource.isPlaying) ||(state == 3 && !audioSource.isPlaying)||(state == 4 && !audioSource.isPlaying)||(state == 5 && !audioSource.isPlaying)) { randomPlay(); }
    }
 
     void randomPlay()
    {
        randomNum = Random.Range(4.0f, 6.0f);
        if (randomNum >= 4.0f && randomNum < 5.0f) { state = 1; audioSource.clip = otherClip1; audioSource.Play(); }
        else if (randomNum >= 5.0f && randomNum < 5.2f) { state = 2; audioSource.clip = otherClip2; audioSource.Play(); }
        else if (randomNum >= 5.2f && randomNum <= 5.4f) { state = 3; audioSource.clip = otherClip3; audioSource.Play(); }
        else if (randomNum >= 5.4f && randomNum <= 5.6f) { state = 4; audioSource.clip = otherClip3; audioSource.Play(); }
        else if (randomNum >= 5.6f && randomNum <= 6.0f) { state = 5; audioSource.clip = otherClip3; audioSource.Play(); }
    }
 
}