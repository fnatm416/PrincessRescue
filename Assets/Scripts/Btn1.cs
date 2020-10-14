using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn1 : MonoBehaviour
{
    //타이틀화면//
    //게임시작
    public void Start_Game()
    {
        SceneManager.LoadScene("Stage1");
    }

    //게임종료
    public void Exit_Game()
    {
        Application.Quit();
    }


    //스테이지1 클리어//
    //재시작
    public void Restart_Btn()
    {
        DataManager.instance.score = 0;   //점수초기화
        DataManager.instance.PlayerDie = false;
        DataManager.instance.HealthCurrent = DataManager.instance.HealthMax;    //체력초기화

        SceneManager.LoadScene("Stage1");
    }

    //메인화면
    public void Main_Btn()
    {
        DataManager.instance.score = 0;   //점수초기화
        DataManager.instance.PlayerDie = false;
        DataManager.instance.HealthCurrent = DataManager.instance.HealthMax;    //체력초기화
        DataManager.instance.stage = 1;
        SceneManager.LoadScene("0_Title");
    }

    //다음스테이지
    public void Next_Stage()
    {
        DataManager.instance.score = 0;   //점수초기화
        DataManager.instance.PlayerDie = false;
        DataManager.instance.HealthCurrent = DataManager.instance.HealthMax;    //체력초기화
        DataManager.instance.mapSpeed = 8;  //속도상승
        SceneManager.LoadScene("Stage2");
    }
}


