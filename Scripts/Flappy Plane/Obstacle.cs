using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f; // 퍼블릭으로 설정한 이유는 Inspector 값을 수정할수있다.
    public float lowPosY = -1f; //상하로 이동할때 얼마나 이동할지 지정

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f; // 탑과 바텀 사이에 공간을 얼마나 가져갈지 만들어줌

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f; // 오브젝트들을 배치할때 사이의 폭을 얼마나 가져갈건지

    Gamemanager gameManager;// 옵스탈클도 게임매니저를 넣어줘야 간편히 구현을 할 수 있다.

    private void Start()
    {
        gameManager = Gamemanager.Instance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount) // 이부분 그냥 이해 x
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax); // 홀사이즈 지정 랜덤한 값을 민 멕스
        float halfHoleSize = holeSize / 2; // 2로 나눠줌

        topObject.localPosition = new Vector3(0, halfHoleSize); // 탑오브젝트 로컬포지션 지정 반만큼 올림
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0); // 
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    void OnTriggerExit2D(Collider2D collision) // 충돌은 하지않고 벗어날때 도출을 한다
    {
        Player player = collision.GetComponent<Player>(); // 나랑 TriggerExit를 진행한 애가 Player라면 Score를 하나 올리겠다.
        if (player != null)
            gameManager.AddScore(1); 
    }
}
