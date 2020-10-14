using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] sources;

    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

            //사운드매니저의 자식오브젝트들을 참조
            sources = GetComponentsInChildren<AudioSource>();
        }
    }

    //특정사운드를 재생시키는 메소드(다른 클래스에서 호출)
    public void PlaySound(string soundName)
    {
        for (int i = 0; i<sources.Length; i++)
        {
            if (sources[i].gameObject.name.CompareTo(soundName) == 0)
            {
                sources[i].Play();
            }
        }
    }
}


