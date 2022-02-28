using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    //������ ź���� ���� ������
    public GameObject bulletPrefab;
    //�ּ� ���� �ֱ�
    public float spawnRateMin = 0.5f;
    //�ִ� ���� �ֱ�
    public float spawnRateMax = 3f;

    //���� ���� �ֱ�
    private float spawnRate;
    //�ֱ� ���� �������� ���� �ð�
    private float timeAfterSpawn;
    //�߻��� ���(-> player)
    private Transform target;
    void Start()
    {
        //�ֱ� ���� ���Ŀ� ���� �ð��� 0���� �ʱ�ȭ/0�� f�� �־ �ȳ־����
        timeAfterSpawn = 0f;
        //ź�� ���� ������spawnRateMin��
        //spawnRateMax ���̿��� ���� �� ����
        spawnRate = Random.Range(spawnRateMin,spawnRateMax);
        //PlayerController ������Ʈ�� ���� ����
        //������Ʈ�� ã�Ƽ� �� ������Ʈ�� ��ġ���� ������
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterspawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            //(�ð� ����)bulletPrefab�� �������� transform.position��ġ��
            //transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //������ bullet ���� ������Ʈ�� ���� ������ (target)�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            //������ ���� ������ spawnRateMin�� spawnRateMax ���̿��� �����ϰ� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            //������ �ð��� ����
            timeAfterSpawn = 0f;


            //float time = Time.deltaTime; - je ne sais pas
            //float sumTime += time;
            //Debug.Log("�����Ӵ� �ð� : " + time);
            //Debug.Log("���� �÷��� �ð� : " + (int)sumTime);

            ////Debug.Log(Time.deltaTime); /�߿���/delta �� �����ӿ� (���)�����Ǵ� �ð�
        }
    }

        
}
