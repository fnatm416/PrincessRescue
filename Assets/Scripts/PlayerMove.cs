using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    int jumpCount = 0;  //점프 횟수
    public float jump = 10f;    //점프 높이
    public float jump2 = 12f;   //2단점프 높이
    public Animator _ani;       //플레이어 모션
    public bool hit = false;    //피격여부
    public SpriteRenderer spr = new SpriteRenderer();
    public CircleCollider2D cc; //서클콜라이더

   

    public void PlayerAni_Run() // 평상 시 애니메이션
    {
        cc.enabled = true;  //상단무적 해제(서클콜라이더 활성화)
        _ani.SetInteger("state", 0);
    }

    public void PlayerAni_Jump()    // 점프 시 애니메이션
    {
        cc.enabled = true;
        _ani.SetInteger("state", 1);
    }

    public void PlayerAni_Slide()   // 슬라이딩 시 애니메이션
    {
        _ani.SetInteger("state", 2);
    }

    public void PlayerAni_Hit() // 피격 시 애니메이션
    {
        _ani.SetInteger("state", 3);
    }

    public void Jump()  //점프
    {
        if (!DataManager.instance.PlayerDie)
        {
            if (jumpCount == 0) //점프를 한번도 안했을 때
            {
                SoundManager.instance.PlaySound("jump");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount += 1; //점프카운트 +1
                PlayerAni_Jump();
            }
            else if (jumpCount == 1) //점프 한번 했을 때
            {
                SoundManager.instance.PlaySound("jump");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                jumpCount += 1; //점프카운트 +1
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Land") == 0)    //착지했을 때
        {
            jumpCount = 0;  //점프카운트 초기화
            PlayerAni_Run();
        }

        if (collision.gameObject.tag.CompareTo("flag") == 0)    //도착지점에 닿았을 때
        {
            if (DataManager.instance.stage == 1)
            {
                SoundManager.instance.PlaySound("clear");   //클리어사운드 출력
                SceneManager.LoadScene("Stage1_Clear");
            }
            else if (DataManager.instance.stage == 2)
            {
                SoundManager.instance.PlaySound("clear");
                SceneManager.LoadScene("Stage2_Clear");
            }
            else if (DataManager.instance.stage == 3)
            {
                SoundManager.instance.PlaySound("clear");
                SceneManager.LoadScene("Stage3_Clear");
            }
        }
    }

    public void Slide() //슬라이딩
    {
        if (!DataManager.instance.PlayerDie)
        {
            cc.enabled = false; //상단 장애물 무적 (서클콜라이더 비활성화)
            SoundManager.instance.PlaySound("slide");
            PlayerAni_Slide();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.instance.PlayerDie)
        {
            if (hit == false)
            {
                if (collision.gameObject.tag.CompareTo("Object") == 0)  //장애물에 피격했을 때
                {
                    SoundManager.instance.PlaySound("hit");
                    hit = true;
                    spr.color = new Color32(255, 255, 255, 90);
                    PlayerAni_Hit();
                    DataManager.instance.HealthCurrent -= 5f; //체력감소
                    Invoke("EnableCol", 1); //1초 후에 EnableCol 호출 (1초 무적)
                }
            }
        }     
    }
    
    //무적시간 끝나면 원래 플레이어 컬러로 변경
    void EnableCol()
    {
        spr.color = new Color32(255, 255, 255, 255);
        hit = false;
    }
}