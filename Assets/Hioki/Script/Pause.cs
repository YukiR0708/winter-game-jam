using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pause : MonoBehaviour
{
    event Action _pause;
    event Action _resume;
    //true�̎��|�[�Y���Ă�
    bool _isPause;

    /// <summary>�|�[�Y����Ƃ��̓��������Ă��炤</summary>
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

    /// <summary>�|�[�Y�ڂ���ɂ���</summary>
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
