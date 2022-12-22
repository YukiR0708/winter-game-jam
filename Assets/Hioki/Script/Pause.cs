using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pause : MonoBehaviour
{
    event Action _pause;
    event Action _resume;
    //trueの時ポーズしてる
    bool _isPause;

    /// <summary>ポーズするときの動きを入れてもらう</summary>
    public Action PauseAction { get => _pause; set => _pause = value; }
    public Action ResumeAction { get => _resume; set => _resume = value; }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(!_isPause)
            {
                OnPause();
            }
            else
            {
                Resume();
            }
        }
    }

    /// <summary>ポーズぼたんにつける</summary>
    public void OnPause()
    {
        if (PauseAction != null)
        {
            PauseAction.Invoke();
            _isPause = true;
        }
    }

    public void Resume()
    {
        if(ResumeAction != null)
        {
            ResumeAction.Invoke();
            _isPause = false;
        }
    }

}
