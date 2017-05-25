using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour
{

    AudioSource[] asc;
    //private static float vol = GameObject.GetComponents<AudioSource>().volume;
    public AudioSource MasterAudioSource;
    // Use this for initialization
    void Start()
    {
        asc = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SetVolume();
    }

    public void SetVolume()
    {
        for (int i = 0; i < asc.Length; i++)
        {
            asc[i].volume = MasterAudioSource.volume;
        }
    }
}
