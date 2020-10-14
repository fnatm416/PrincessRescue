using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image Health;    //체력바
    public GameObject[] NumberImage;    //스코어
    public Sprite[] Number;

    void Update()
    {
        //체력바 관련 코드
        if (!DataManager.instance.PlayerDie)
        {
            // 1초에 1씩 감소
            DataManager.instance.HealthCurrent -= 1 * Time.deltaTime;
            // 시간이 다 되면 죽음
            if (DataManager.instance.HealthCurrent < 0)
            {
                DataManager.instance.PlayerDie = true;
            }
        }

        if (!DataManager.instance.PlayerDie)
        {   // 1초에 1씩 감소
            DataManager.instance.HealthCurrent -= 1 * Time.deltaTime;
            // 0~1까지 체력바의 범위 결정. 다 채워져 있는 상태가 1
            Health.fillAmount = DataManager.instance.HealthCurrent / DataManager.instance.HealthMax;

            if (DataManager.instance.HealthCurrent < 0)
            {
                DataManager.instance.PlayerDie = true;
            }
        }

        //실패창
        if (DataManager.instance.stage == 1)
        {
            if (DataManager.instance.PlayerDie == true)
            {
                SoundManager.instance.PlaySound("gameover");
                SceneManager.LoadScene("Stage1_GameOver");
            }
        }
        else if (DataManager.instance.stage==2)
        { 
            if (DataManager.instance.PlayerDie == true)
            {
                SoundManager.instance.PlaySound("gameover");
                SceneManager.LoadScene("Stage2_GameOver");
            }
        }
        else if (DataManager.instance.stage == 3)
        {
            if (DataManager.instance.PlayerDie == true)
            {
                SoundManager.instance.PlaySound("gameover");
                SceneManager.LoadScene("Stage3_GameOver");
            }
        }

        //점수 갱신
        //1000의 자리
        int temp = DataManager.instance.score / 1000;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp];
        //100의 자리
        int temp2 = DataManager.instance.score % 1000;
        temp2 = temp2 / 100;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp2];
        //10의 자리
        int temp3 = DataManager.instance.score % 100;
        temp3 = temp3 / 10;
        NumberImage[2].GetComponent<Image>().sprite = Number[temp3];
        //1의 자리
        int temp4 = DataManager.instance.score % 10;
        NumberImage[3].GetComponent<Image>().sprite = Number[temp4];
    }
}