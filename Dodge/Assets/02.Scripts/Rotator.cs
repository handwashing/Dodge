using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
   
 
    void Update()
    {
        //rotate �޼���� �Է°�(�Ű�����)�� xyz�࿡���� ȸ������ �ް�,
        //���� ȸ�� ���¿��� �Էõ� ����ŭ ��������� �� ȸ��
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
