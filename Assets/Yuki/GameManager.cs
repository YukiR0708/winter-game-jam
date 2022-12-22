using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStatus state = GameStatus.Title;

    //***�v���C���[��UI�ؑ֊֌W***
    [SerializeField] GameObject _player1 = default;
    [SerializeField] GameObject _player2 = default;
    [Tooltip("1P�̃X�v���C�g�����_���[")] SpriteRenderer _p1SpriteRenderer = default;
    [Tooltip("2P�̃X�v���C�g�����_���[")] SpriteRenderer _p2SpriteRenderer = default;


    /// <summary>���݂̃Q�[����ԊǗ��p</summary>
    [Flags]
    public enum GameStatus
    {
        Title = 1 << 0,  //�^�C�g��,��������� 
        InGame = 1 << 1, //�Q�[��
        Kyoryoku = 1 << 2, //���̓��[�h
        Battle = 1 << 3, //�o�g��
        Pause = 1 << 4, //�|�[�Y
        UnPause = 1 << 5,    //�|�[�Y����
        Clear = 1 << 6, //�N���A
        Failed = 1 << 7, //���s
    }

    void Start()
    {
        //***�v���C���[��UI�ؑ�***
        _p1SpriteRenderer = _player1.GetComponent<SpriteRenderer>();
        _p2SpriteRenderer = _player2.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }

    /// <summary>�e��������Ă�ł��炤</summary>
    /// <param name="player"></param>
    public void PlayerChange(bool player)
    {
        //***�v���C���[��UI�ؑ�***
        if (player)//1P��������
        {
            _p1SpriteRenderer.color = new Color(255, 255, 255); //1P���邭����
            _p2SpriteRenderer.color = new Color(130, 130, 130); //2P�Â�����
        }
        else
        {
            //2P��������
            _p2SpriteRenderer.color = new Color(255, 255, 255); //2P���邭����
            _p1SpriteRenderer.color = new Color(130, 130, 130); //1P�Â�����
        }
    }
}
