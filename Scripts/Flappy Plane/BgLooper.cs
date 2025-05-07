using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero; // 0,0,0 의 위치에다가 만들어준다.
   
    void Start() // 장애물을 처음 옵스타클 부터 마지막 옵스타클까지 배치를 해준다.
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // GameObject 클래스 사용 FindObjectsOfType 코드가 들어 있고 사용시 이 씬에 존재하는 모든 오브젝트들을 돌아다니면서 Obstacle이 달려 있는지를 찾아온다.
        obstacleLastPosition = obstacles[0].transform.position; // 옵스타클 라스트 포지션은 옵스타클 첫번째 포지션으로 간다.
        obstacleCount = obstacles.Length; //배열이니깐 렝스로

        for (int i = 0; i < obstacleCount; i++) // 반복문 옵스타클을 랜덤배치해준다.
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 트리거는 통보만 해준다.
    {
        Debug.Log("Triggerd: " + collision.name);

        if(collision.CompareTag("BackGround")) // 이해를 못함 다시 들어야하나
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x; 
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>(); // 옵스타클있는지 확인
        if (obstacle) //옵스타클이 널이 아니라면 
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount); //충돌한애가 어떤애인지 확인할때 쓴다?
        }
    }
}
