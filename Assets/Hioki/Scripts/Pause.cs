using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    event Action _pause;

    /// <summary>ポーズするときの動きを入れてもらう</summary>
    public Action PauseAction { get => _pause; set => _pause = value; }

    /// <summary>ポーズぼたんにつける</summary>
    public void OnPause()
    {
        if (PauseAction != null)
        {
            PauseAction.Invoke();
            Debug.Log("pause");
        }
    }
}
