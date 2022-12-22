using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    event Action _pause;

    /// <summary>�|�[�Y����Ƃ��̓��������Ă��炤</summary>
    public Action PauseAction { get => _pause; set => _pause = value; }

    /// <summary>�|�[�Y�ڂ���ɂ���</summary>
    public void OnPause()
    {
        if (PauseAction != null)
        {
            PauseAction.Invoke();
            Debug.Log("pause");
        }
    }
}
