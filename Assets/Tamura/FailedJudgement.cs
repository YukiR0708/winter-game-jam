using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>落ちた判定　TriggerでもCollisionでもいけます</summary>
public class FailedJudgement : MonoBehaviour
{
    GameManager _gameManager;
    [SerializeField, Header("1P側のStackMochiManager")] StackMochiManager _player1;
    [SerializeField, Header("2P側のStackMochiManager")] StackMochiManager _player2;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //協力モードだったら失敗
        if(_gameManager.state.HasFlag(GameManager.GameStatus.Kyoryoku))
        {
            _gameManager.state |= GameManager.GameStatus.Failed;
        }
        //バトルモードだったら
        else if(_gameManager.state.HasFlag(GameManager.GameStatus.Battle))
        {
            //当たったもち持ってくる
            var go = collision.gameObject;

            if(go.GetComponent<Mochi>().Player) //1P
            {
                
                //すでに積まれてるもちだったら、リストから消す
                if(_player1.StackedMochiList.Contains(go))
                {
                    _player1.StackedMochiList.Remove(go);
                }

                //次のもち召喚
                _player1.TargetChange();
            }
            else //2P
            {
                //すでに積まれてるもちだったら、リストから消す
                if (_player2.StackedMochiList.Contains(go))
                {
                    _player2.StackedMochiList.Remove(go);
                }

                //次のもち召喚
                _player2.TargetChange();
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //協力モードだったら失敗
        if (_gameManager.state.HasFlag(GameManager.GameStatus.Kyoryoku))
        {
            _gameManager.state |= GameManager.GameStatus.Failed;
        }
        //バトルモードだったら
        else if (_gameManager.state.HasFlag(GameManager.GameStatus.Battle))
        {
            //当たったもち持ってくる
            var go = collision.gameObject;

            if (go.GetComponent<Mochi>().Player) //1P
            {

                //すでに積まれてるもちだったら、リストから消す
                if (_player1.StackedMochiList.Contains(go))
                {
                    _player1.StackedMochiList.Remove(go);
                }

                //次のもち召喚
                _player1.TargetChange();
            }
            else //2P
            {
                //すでに積まれてるもちだったら、リストから消す
                if (_player2.StackedMochiList.Contains(go))
                {
                    _player2.StackedMochiList.Remove(go);
                }

                //次のもち召喚
                _player2.TargetChange();
            }

        }

    }

}
