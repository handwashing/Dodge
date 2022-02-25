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
    private float timeAfterspawn;
    //�߻��� ���
    private Transform target;
    void Start()
    {
        //�ֱ� ���� ���Ŀ� ���� �ð��� 0���� �ʱ�ȭ/0�� f�� �־ �ȳ־����
        timeAfterspawn = 0f;
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
        //�ð� ����(�̾߱Ⱑ ��������� �����Ͽ� �ϱ��...)
        //Instantiate(bulletPrefab);
    }
}
