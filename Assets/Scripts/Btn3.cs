using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn3 : MonoBehaviour
{
    //재시작
    public void Restart_Btn()
    {
        DataManager.instance.score = 0;   //점수초기화
        DataManager.instance.PlayerDie = false;
        DataManager.instance.HealthCurrent = DataManager.instance.HealthMax;    //체력초기화

        SceneManager.LoadScene("Stage3");
    }

    //메인화면
    public void Main_Btn()
    {
        DataManager.instance.score = 0;   //점수초기화
        DataManager.instance.PlayerDie = false;
        DataManager.instance.HealthCurrent = DataManager.instance.HealthMax;    //체력초기화

        SceneManager.LoadScene("0_Title");
    }
}
