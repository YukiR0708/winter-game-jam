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

    /// <summary>�|�[�Y�ĊJ����Ƃ��̓��������Ă��炤</summary>
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

    /// <summary>�|�[�Y�{�^���ɂ���</summary>
    public void OnPause()
    {
        if (_pause != null)
        {
            _pause.Invoke();
            _isPause = true;
        }
    }

    /// <summary>�|�[�Y��߂�{�^���ɂ���</summary>
    public void Resume()
    {
        if (_resume != null)
        {
            _resume.Invoke();
            _isPause = false;
        }
    }
}
