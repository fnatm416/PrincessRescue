using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어와 충돌시 체력회복 후 포션오브젝트 제거
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            SoundManager.instance.PlaySound("posion");
            DataManager.instance.HealthCurrent += 5;
            gameObject.SetActive(false);
        }
    }
}
