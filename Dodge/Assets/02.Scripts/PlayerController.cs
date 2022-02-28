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

        //���� �̵� �ӵ��� �Էư���
        //�̵� �ӷ��� ����� ����
        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        // vector3 �ӵ��� (xSpeed, 0f, zSpeed) ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
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
    public void Die()
    {
        my.SetActive(false);

        //���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager =
            FindObjectOfType<GameManager>();

        gameManager.EndGame();
        
        //gameObject.SetActive(false);
    }
}
