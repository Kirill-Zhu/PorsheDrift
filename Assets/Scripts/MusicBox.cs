using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBox : MonoBehaviour
{
    public static MusicBox instance;
    [SerializeField] Scrollbar volume;
    private AudioSource musicSource;
    public AudioClip[] tracks;
    private void Start()
    {
       if(instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = false;
    }
    private void Update()
    {
        if(!musicSource.isPlaying)
        {
            musicSource.clip = GetRandomTrack();
            musicSource.Play();
        }
        musicSource.volume = volume.value;
    }


private AudioClip GetRandomTrack()
    {
        return tracks[Random.Range(0, tracks.Length)];
    }
}
