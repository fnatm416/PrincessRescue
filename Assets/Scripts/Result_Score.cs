using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_Score : MonoBehaviour
{
    public GameObject[] NumberImage;    //스코어
    public Sprite[] Number;
    void Update()
    {
        //점수
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
