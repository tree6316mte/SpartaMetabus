using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuickClick
{
    public class GameManager : MonoBehaviour
    {

        public TextMeshProUGUI timerText;
        public TextMeshProUGUI bestTimerText;
        public float timeRemaining = 10.0f; // 10초에서 시작
        private bool isGameOver = true;

        public GameObject clickButton;
        public GameObject clickStartButton;

        void Start()
        {
            bestTimerText.text = "현재 최고 기록은 " + PlayerPrefs.GetFloat("QuickClickBestTime", 10).ToString("F4") + "초 입니다.";
        }

        void Update()
        {
            if (!isGameOver)
            {
                timeRemaining -= Time.deltaTime; // 1초에 60~144번 호출됨

                // 0.0001초 단위로 표현 (소수점 4자리까지)
                if (timeRemaining < 0)
                {
                    timeRemaining = 0;
                    GameOver();
                }
                timerText.text = timeRemaining.ToString("F4");
                // Debug.Log($"남은 시간: {timeRemaining:F4} 초");
            }
        }

        public void OnClickStopTimer()
        {
            if (!isGameOver)
            {
                isGameOver = true;
                if (PlayerPrefs.GetFloat("QuickClickBestTime", 10) > timeRemaining)
                {
                    PlayerPrefs.SetFloat("QuickClickBestTime", timeRemaining);
                }
                bestTimerText.text = "현재 최고 기록은 " + PlayerPrefs.GetFloat("QuickClickBestTime", 10).ToString("F4") + "초 입니다.";
                clickButton.SetActive(false);
                clickStartButton.SetActive(true);
            }
        }

        public void OnClickGameStart()
        {
            timeRemaining = 10.0f;
            isGameOver = false;
            clickButton.SetActive(true);
            clickStartButton.SetActive(false);
        }

        public void OnClickQuit()
        {
            SceneManager.LoadScene("SpartaMetabus");
        }

        void GameOver()
        {
            isGameOver = true;
            Debug.Log("게임 오버!");
            clickButton.SetActive(false);
            clickStartButton.SetActive(true);
            // 여기에 게임 오버 로직 추가 (예: 씬 변경, UI 표시 등)
        }
    }
}
