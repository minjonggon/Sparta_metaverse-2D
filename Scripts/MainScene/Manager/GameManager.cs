using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform player;      // 플레이어 Transform
    [SerializeField] Transform flagPoint;   // 노란 깃발 Transform
    [SerializeField] GameObject startPanel; // StartPanel 오브젝트
    [SerializeField] float triggerDistance = 0.5f;  // "닿았다" 판단할 거리

    // bool hasShown = false; // 한 번만 켜지도록 플래그

    void Start()
    {
        startPanel.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, flagPoint.position);

        bool isNearFlag = dist <= triggerDistance; 
        startPanel.SetActive(isNearFlag);
        // if (hasShown) return; // 이미 켜졌으면 더 비교 안 함

        // float dist = Vector3.Distance(player.position, flagPoint.position);
        // if (dist <= triggerDistance)
        // {
        //     startPanel.SetActive(true);
        //     hasShown = true;
        // }
    }
}
