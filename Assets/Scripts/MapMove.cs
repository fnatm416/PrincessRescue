using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{

    private void Update()
    {
        if (!DataManager.instance.PlayerDie)
        {
            //맵스피드만큼 -x 만큼 이동
            transform.Translate(-(DataManager.instance.mapSpeed) * Time.deltaTime, 0, 0);
        }
    }
}