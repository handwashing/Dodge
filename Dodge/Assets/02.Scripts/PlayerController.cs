using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    public Rigidbody playerRigidbody;
    //이동속력 *(public)
    public float speed = 8f;

    //내 자신을 담을 변수
    public GameObject my;

    private void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아서 플레이어
        //리지드 바디에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //수평축과 수직축의 입력값을 감지해 저장
        float xinput = Input.GetAxis("Horizontal");
        //'A'(왼) 음의방향~-1.0f /'D'(오) 양~+1.0f
        float zinput = Input.GetAxis("Vertical");
        //'W'(위) 양의방향~1.0f / 'S'(아래)음 ~-1.0f

        //실제 이동 속도를 입렵값과
        //이동 속력을 사용해 결정
        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        // vector3 속도를 (xSpeed, 0f, zSpeed) 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
    }
        
    
    void Directinput()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)//xyz
        {
            //위쪽
            playerRigidbody.AddForce(0f, 0f, speed);

        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        { //x로 힘주기
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {//아래/ -z 방향으로 힘주기
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
    }
    public void Die()
    {
        my.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager =
            FindObjectOfType<GameManager>();

        gameManager.EndGame();
        
        //gameObject.SetActive(false);
    }
}
