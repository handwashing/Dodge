using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    //생성할 탄알의 원본 프리팹
    public GameObject bulletPrefab;
    //최소 생성 주기
    public float spawnRateMin = 0.5f;
    //최대 생성 주기
    public float spawnRateMax = 3f;

    //실제 생성 주기
    private float spawnRate;
    //최근 생성 시점에서 지난 시간
    private float timeAfterspawn;
    //발사할 대상
    private Transform target;
    void Start()
    {
        //최근 생성 이후에 누적 시간을 0으로 초기화/0은 f를 넣어도 안넣어도ㅇㅋ
        timeAfterspawn = 0f;
        //탄알 생성 간격을spawnRateMin과
        //spawnRateMax 사이에서 랜덤 값 지정
        spawnRate = Random.Range(spawnRateMin,spawnRateMax);
        //PlayerController 컴포넌트를 가진 게임
        //오브젝트를 찾아서 그 오브젝트의 위치값을 가져와
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //시간 누적(이야기가 길어짐으로 월요일에 하기로...)
        //Instantiate(bulletPrefab);
    }
}
