using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>���s����@Trigger�ł�Collision�ł������܂�</summary>
public class FailedJudgement : MonoBehaviour
{
    GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameManager.state |= GameManager.GameStatus.Failed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _gameManager.state |= GameManager.GameStatus.Failed;
    }

}
