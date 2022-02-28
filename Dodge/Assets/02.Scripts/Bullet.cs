using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�ҷ��� ����� ������ٵ� ���۳�Ʈ
    private Rigidbody bulletRigidbody;
    //ź�� �̵� �ӷ�
    public float speed = 8f;
    void Start()
    {
        //���ӿ�����Ʈ���� ������ٵ� ���۳�Ʈ�� ã�� 
        //�ҷ�������ٵ� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        //���� ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�;
        bulletRigidbody.velocity = transform.forward * speed;
        // vector3 (x,y,z) = (0,0,1) // back -> forward*-1

        Destroy(gameObject, 3f);
        //3f�� ���� �ð�
    }
    //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    private void OnTriggerEnter(Collider other)
    {
      //�浹�� ���� ���� ������Ʈ�� �÷��̾� �±׸� ��������?
      if(other.tag == "Player")
        {
            //����(�浹��) ���� ������Ʈ����
            //�÷��̾� ��Ʈ�ѷ� ������Ʈ�� ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            //�������κ��� PlayerController ������Ʈ��
            //�������µ� �����ߴٸ�
            if(playerController != null)
            {
                //playerController ������Ʈ�� 
                //Die() �޼��� ����
                playerController.Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
