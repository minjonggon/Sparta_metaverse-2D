using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f; // 점프하는 힘
    public float forwardSpeed = 3f; // 정면으로 이동하는힘
    public bool isDead = false; // 죽었는지 살았는지 구분
    float deathCooldown = 0f; // 일정시간있다가 죽을수있도록

    bool isFlap = false; // 점프를 뛰었는 안뛰었는지 구분
    public bool godMode = false; // 갓모드 설정

    Gamemanager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Gamemanager.Instance; // 게임매니저에서 게임매니저를 호출하는게 awake이기때문에 start로 호출

        animator = GetComponentInChildren<Animator>(); // GetComponet란 우리가 찾고 있는 컴포넌트가 달려있는지 달려있다면 그걸 반환해주는 기능 GetComponentInChildren InChildren이 붙는다면 내 오브젝트에서만 찾는 GetComponet과 달리 하위 오브젝트를 검색 진행할수있음
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not Founded Animator");
        
        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            if(deathCooldown <= 0)
            {
                //게임 재시작
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // 0 마우스 오른쪽 1 마우스 왼쪽 0 스마트폰 터치 기능 포함, input은 마우스,키보드,터치 사용자 입력을 처리하는 사용
            {
               gameManager.RestartGame(); // 쿨다운이 끝났을때 클릭을 하면 다시 재시작을 할 수 있게 하는 구조
            }
            }
            else
            {
                deathCooldown -= Time.deltaTime; //이전 프레임과 현재 프레임 사이의 시간을 의미한다. 
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // 0 마우스 오른쪽 1 마우스 왼쪽 0 스마트폰 터치 기능 포함, input은 마우스,키보드,터치 사용자 입력을 처리하는 사용
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate() // 물리처리를 하기 위해서 만듬
    {
        if (isDead) return; // 죽었다면 리턴

        Vector3 velocity = _rigidbody.velocity; // 벨로시티는 가속도, 리지드바디가 가지고 있는 가속도를 가져올거다. 물리적으로 받고 있는 힘을 가져온다
        velocity.x = forwardSpeed; // 벨로시티 엑스값을 포워드스피드로 만들어줬다. 애는 똑같은 속도로 이동할거다.

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity; // 넣어주는 작업을 해줌 위에는 복사만 했기때문에 적용되지않았음. 이 작업을 해서 기능이 활성화된거같음?

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f) , -90, 90); // 각도 회전 clamp는 값을 제한을 둔다. 특정한 값을  min, max로 구분한다. velocity y값이 올라가고 있는지 구분해주는 값임
        transform.rotation = Quaternion.Euler(0, 0, angle); // transform은 너무 자주 사용해서 바로 사용할수있드록 내장되어있다. rotation은 Quaternion이라는 사원수값을 사용 우리가 원하느 방식대로는 회전하기 어렵, 그래서 Euler을 사용 Euler는 각도를 의미한다.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}
