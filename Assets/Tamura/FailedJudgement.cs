using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>����������@Trigger�ł�Collision�ł������܂�</summary>
public class FailedJudgement : MonoBehaviour
{
    GameManager _gameManager;
    [SerializeField, Header("1P����StackMochiManager")] StackMochiManager _player1;
    [SerializeField, Header("2P����StackMochiManager")] StackMochiManager _player2;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //���̓��[�h�������玸�s
        if(_gameManager.state.HasFlag(GameManager.GameStatus.Kyoryoku))
        {
            _gameManager.state |= GameManager.GameStatus.Failed;
        }
        //�o�g�����[�h��������
        else if(_gameManager.state.HasFlag(GameManager.GameStatus.Battle))
        {
            //�����������������Ă���
            var go = collision.gameObject;

            if(go.GetComponent<Mochi>().Player) //1P
            {
                
                //���łɐς܂�Ă������������A���X�g�������
                if(_player1.StackedMochiList.Contains(go))
                {
                    _player1.StackedMochiList.Remove(go);
                }

                //���̂�������
                _player1.TargetChange();
            }
            else //2P
            {
                //���łɐς܂�Ă������������A���X�g�������
                if (_player2.StackedMochiList.Contains(go))
                {
                    _player2.StackedMochiList.Remove(go);
                }

                //���̂�������
                _player2.TargetChange();
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //���̓��[�h�������玸�s
        if (_gameManager.state.HasFlag(GameManager.GameStatus.Kyoryoku))
        {
            _gameManager.state |= GameManager.GameStatus.Failed;
        }
        //�o�g�����[�h��������
        else if (_gameManager.state.HasFlag(GameManager.GameStatus.Battle))
        {
            //�����������������Ă���
            var go = collision.gameObject;

            if (go.GetComponent<Mochi>().Player) //1P
            {

                //���łɐς܂�Ă������������A���X�g�������
                if (_player1.StackedMochiList.Contains(go))
                {
                    _player1.StackedMochiList.Remove(go);
                }

                //���̂�������
                _player1.TargetChange();
            }
            else //2P
            {
                //���łɐς܂�Ă������������A���X�g�������
                if (_player2.StackedMochiList.Contains(go))
                {
                    _player2.StackedMochiList.Remove(go);
                }

                //���̂�������
                _player2.TargetChange();
            }

        }

    }

}
