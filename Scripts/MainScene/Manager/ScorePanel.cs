using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] Transform player2;      // 플레이어 Transform
    [SerializeField] Transform flagPoint2;   // 빨간 깃발 Transform
    [SerializeField] GameObject ScoreUI; // ScoreUI 오브젝트
    [SerializeField] float triggerDistance2 = 0.5f;  // "닿았다" 판단할 거리
    //UI On Off 만들기 
    void Start()
    {
        ScoreUI.SetActive(false); // 시작할 때 꺼두기
    }

    void Update()
    {

        float dist = Vector3.Distance(player2.position, flagPoint2.position); // 매 프레임 거리 계산

        bool isNearFlag = dist <= triggerDistance2; // 닿았을 때만 켜고, 벗어나면 꺼버리기
        ScoreUI.SetActive(isNearFlag);

    }
}
