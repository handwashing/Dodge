using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    public Rigidbody playerRigidbody;
    //�̵��ӷ� *(public)
    public float speed = 8f;

    //�� �ڽ��� ���� ����
    public GameObject my;

    private void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�Ƽ� �÷��̾�
        //������ �ٵ� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //������� �������� �Է°��� ������ ����
        float xinput = Input.GetAxis("Horizontal");
        //'A'(��) ���ǹ���~-1.0f /'D'(��) ��~+1.0f
        float zinput = Input.GetAxis("Vertical");
        //'W'(��) ���ǹ���~1.0f / 'S'(�Ʒ�)�� ~-1.0f
    }
        
    
    void Directinput()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)//xyz
        {
            //����
            playerRigidbody.AddForce(0f, 0f, speed);

        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        { //x�� ���ֱ�
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {//�Ʒ�/ -z �������� ���ֱ�
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
    }
void Die()
    {
        my.SetActive(false);
        
        gameObject.SetActive(false);
    }
}
