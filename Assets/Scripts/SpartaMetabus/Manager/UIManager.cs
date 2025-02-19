using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";
    private const string BestComboKey = "BestCombo";

    public TextMeshProUGUI quickClickBestScore;

    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI bestCombo;
    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = PlayerPrefs.GetInt(BestScoreKey, 0).ToString();
        bestCombo.text = PlayerPrefs.GetInt(BestComboKey, 0).ToString();

        quickClickBestScore.text = PlayerPrefs.GetFloat("QuickClickBestTime", 0).ToString("F4");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
