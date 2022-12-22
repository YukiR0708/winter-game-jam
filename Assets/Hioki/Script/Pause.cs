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

    /// <summary>ポーズ再開するときの動きを入れてもらう</summary>
    public Action ResumeAction { get => _resume; set => _resume = value; }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!_isPause)
            {
                OnPause();
            }
            else
            {
                Resume();
            }
        }
    }

    /// <summary>ポーズボタンにつける</summary>
    public void OnPause()
    {
        if (_pause != null)
        {
            _pause.Invoke();
            _isPause = true;
        }
    }

    /// <summary>ポーズやめるボタンにつける</summary>
    public void Resume()
    {
        if (_resume != null)
        {
            _resume.Invoke();
            _isPause = false;
        }
    }
}
