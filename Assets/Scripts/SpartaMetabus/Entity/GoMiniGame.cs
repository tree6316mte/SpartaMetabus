using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMiniGame : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(sceneName);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
