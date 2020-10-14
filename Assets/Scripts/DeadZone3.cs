using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone3 : MonoBehaviour
{
    //스테이지 세팅
    private void Awake()
    {
        DataManager.instance.stage = 3;
        DataManager.instance.mapSpeed = 9;
    }

    //데드존에 닿을 시, 플레이어 사망처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.instance.PlayerDie)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                DataManager.instance.PlayerDie = true;
            }
        }
    }
}