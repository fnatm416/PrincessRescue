using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해상도를 1920x1080 으로 고정시키는 스크립트
public class Resolution : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1920,1080,true);
    }
}
