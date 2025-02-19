using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEventHandler : MonoBehaviour
{
    Action enterAction;
    Action exitAction;
    public void Init(Action _enterAction, Action _exitAction)
    {
        enterAction = _enterAction;
        exitAction = _exitAction;
    }
    void OnTriggerEnter2D()
    {
        enterAction();
    }

    void OnTriggerExit2D()
    {
        exitAction();
    }
}
