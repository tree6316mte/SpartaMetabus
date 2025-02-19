using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI restartText;

        public void Start()
        {
            if (restartText == null)
            {
                Debug.LogError("restart text is null");
            }

            if (scoreText == null)
            {
                Debug.LogError("scoreText is null");
                return;
            }

            restartText.gameObject.SetActive(false);
        }

        public void SetRestart()
        {
            restartText.gameObject.SetActive(true);
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
        public void OnClickExit()
        {
            SceneManager.LoadScene("SpartaMetabus");
            return;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
        }
    }
}