using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //싱글톤 클래스
    public static DataManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    //초기값 설정
    public int stage = 1;
    public int score = 0;
    public float HealthCurrent = 10f;
    public float HealthMax = 10f;
    public bool PlayerDie = false;
    public float mapSpeed = 8f;
}