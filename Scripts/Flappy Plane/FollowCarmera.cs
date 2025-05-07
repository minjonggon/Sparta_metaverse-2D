using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCarmera : MonoBehaviour // 이 코드가 어떤 코드인지 설명해주고, 한줄 마다 주석처리해서 상세하게 설명해줘. 나는 코딩 초보중에 개초보야.
{
    public Transform target; // player
    float offsetX;
    
    void Start()
    {
        if (target == null) 
            return;

        offsetX = transform.position.x - target.position.x; // 카메라 포지션 x값에서 플레이어 포지션 x값을 빼준다. 처음에 배치했을때 카메라하고 플레이어 사이의 거리가 저장된다. 그 거리를 유지하면서 이동한다.
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position; // 내 위치 가져오기
        pos.x = target.position.x + offsetX; // 캐릭터가 이동하는걸 따라가는데 캐릭터의 위치로 카메라가 가는게 아니라 캐릭터 위치보다 offset, 처음에 배치해놓은 거리만큼 떨어진 상태로 계속 따라간다.
        transform.position = pos;
    }
}
