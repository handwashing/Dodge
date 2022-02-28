using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //불렛에 사용할 리지드바디 컴퍼넌트
    private Rigidbody bulletRigidbody;
    //탄알 이동 속력
    public float speed = 8f;
    void Start()
    {
        //게임오브젝트에서 리지드바디 컴퍼넌트를 찾아 
        //불렛리지드바디에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        //실제 리지드바디의 속도 = 앞쪽 방향 * 이동 속력;
        bulletRigidbody.velocity = transform.forward * speed;
        // vector3 (x,y,z) = (0,0,1) // back -> forward*-1

        Destroy(gameObject, 3f);
        //3f가 지연 시간
    }
    //트리거 충돌 시 자동으로 실행되는 메서드
    private void OnTriggerEnter(Collider other)
    {
      //충돌한 상대방 게임 오브젝트가 플레이어 태그를 가졌나요?
      if(other.tag == "Player")
        {
            //상대방(충돌한) 게임 오브젝트에서
            //플레이어 컨트롤러 컴포넌트를 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 PlayerController 컴포넌트를
            //가져오는데 성공했다면
            if(playerController != null)
            {
                //playerController 컴포넌트의 
                //Die() 메서드 실행
                playerController.Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
