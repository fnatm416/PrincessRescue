using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어와 충돌하면 점수10점추가, 동전오브젝트 제거
        if (collision.gameObject.tag=="Player")
        {
            SoundManager.instance.PlaySound("coin");
            DataManager.instance.score += 10;
            gameObject.SetActive(false);   
        }
    }
}
