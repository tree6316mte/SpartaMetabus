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
        public float timeRemaining = 10.0f; // 10�ʿ��� ����
        private bool isGameOver = true;

        public GameObject clickButton;
        public GameObject clickStartButton;

        void Start()
        {
            bestTimerText.text = "���� �ְ� ����� " + PlayerPrefs.GetFloat("QuickClickBestTime", 10).ToString("F4") + "�� �Դϴ�.";
        }

        void Update()
        {
            if (!isGameOver)
            {
                timeRemaining -= Time.deltaTime; // 1�ʿ� 60~144�� ȣ���

                // 0.0001�� ������ ǥ�� (�Ҽ��� 4�ڸ�����)
                if (timeRemaining < 0)
                {
                    timeRemaining = 0;
                    GameOver();
                }
                timerText.text = timeRemaining.ToString("F4");
                // Debug.Log($"���� �ð�: {timeRemaining:F4} ��");
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
                bestTimerText.text = "���� �ְ� ����� " + PlayerPrefs.GetFloat("QuickClickBestTime", 10).ToString("F4") + "�� �Դϴ�.";
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
            Debug.Log("���� ����!");
            clickButton.SetActive(false);
            clickStartButton.SetActive(true);
            // ���⿡ ���� ���� ���� �߰� (��: �� ����, UI ǥ�� ��)
        }
    }
}
