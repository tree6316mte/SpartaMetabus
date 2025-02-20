using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxHandler : MonoBehaviour
{
    public GameObject but;
    public GameObject box;
    void OnTriggerEnter2D()
    {
        but.SetActive(true);
    }
    void OnTriggerStay2D()
    {
        if (Input.GetKey(KeyCode.F))
        {
            box.SetActive(true);
        }
    }
    void OnTriggerExit2D()
    {
        but.SetActive(false);
    }
}
