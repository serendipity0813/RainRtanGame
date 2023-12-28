using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rain;
    public GameObject panel;
    public static GameManager I;
    int totalScore = 0;
    public Text scoreText;
    public Text timeText;
    float limit = 3f;


    void Awake() 
    {
        //싱글톤화 하기
        I = this;
    }

    // Start is called before the first frame update
    void Start() 
    {
        InitGame();
        //시간 단위로 빗물 떨어트리기
        InvokeRepeating("MakeRain", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //시간이 흐르도록 하기
        limit -= Time.deltaTime;
        timeText.text = limit.ToString("N2");
        //멈추게 하기
        if (limit < 0)
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            limit = 0.0f;
        }
    }
    
    void MakeRain() 
    {
        //빗물 만들기
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        //점수 올리기
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        // 게임 재시작 
        SceneManager.LoadScene("MainScene");
    }
    void InitGame()
    {
        //게임환경 초기화
        Time.timeScale = 1;
        totalScore = 0;
        limit = 30f;

    }
}
