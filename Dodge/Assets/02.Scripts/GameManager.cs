using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI 관련 라이브러리 사용할래
using UnityEngine.UI;
// 씬 관리 관련 라이브러리 사용할래
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    // 게임오버시 활성화할 텍스트 게임 오브젝트
    public GameObject gameOverText;
    //생존시간을 표시할 텍스트 컴포넌트
    public Text timeText;
    //최고기록을 표시할 텍스트 컴포넌트
    public Text recordText;

    //실제 생존 시간
    private float surviveTime;
    //게임오버 상태
    private bool isGameover;

    void Start()
    {
        //생존시간과 게임오버상태 초기화
        surviveTime = 0f;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        //게임오버가 아닌 동안 
        if(!isGameover)
        {
            //생존시간갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존시간을 timeText컴포넌트를 이용해 표시
            timeText.text = "Time : " + (int)surviveTime;
            //(text는 변수임 / ) (int)로 형변환 -> / "" - 문자열로 인식 , 나머지도 자동으로 문자로 인식..
            //ex) timeText.text = "Time : " + surviveTime.Tostring; / 
        }
        else
        {
            //게임오버인 상태에서 'R'키를 누른다면
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 을 로드
                SceneManager.LoadScene("SampleScene"); //(0)

            }
        }
    }

    //현재 게임을 게임오버상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameOverText.SetActive(true);
        //timeText.enabled = true; 

        // 'BestTime' 키로 지정된 이전까지의
        // 최고 기록을 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록과 현재 생존 시간을 비교
        if(bestTime < surviveTime)
        {
            //최고 기록 값을
            //현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 'BestTime'키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //최고 기록을 recordText 컴퍼넌트에 표시
        recordText.text = "Best Time : " + (int)bestTime;
    }
}
