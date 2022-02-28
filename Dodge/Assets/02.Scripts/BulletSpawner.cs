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
    private float timeAfterSpawn;
    //발사할 대상(-> player)
    private Transform target;
    void Start()
    {
        //최근 생성 이후에 누적 시간을 0으로 초기화/0은 f를 넣어도 안넣어도ㅇㅋ
        timeAfterSpawn = 0f;
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
        //timeAfterspawn 갱신
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(timeAfterSpawn >= spawnRate)
        {
            //(시간 누적)bulletPrefab의 복제본을 transform.position위치와
            //transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //생성된 bullet 게임 오브젝트의 정면 방향이 (target)을 향하도록 회전
            bullet.transform.LookAt(target);

            //다음번 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤하게 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            //누적된 시간을 리셋
            timeAfterSpawn = 0f;


            //float time = Time.deltaTime; - je ne sais pas
            //float sumTime += time;
            //Debug.Log("프레임당 시간 : " + time);
            //Debug.Log("현재 플레이 시간 : " + (int)sumTime);

            ////Debug.Log(Time.deltaTime); /중요함/delta 한 프레임에 (재생)누적되는 시간
        }
    }

        
}
