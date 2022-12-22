using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    public GameStatus state = GameStatus.Title;
    //***�c�莞�Ԋ֌W***
    [SerializeField] float _time = default;
    [SerializeField] Text _timeText = default;

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
        Kyoryoku = 1 << 1, //���̓��[�h
        Battle = 1 << 2, //�o�g��
        Pause = 1 << 3, //�|�[�Y
        UnPause = 1 << 4,    //�|�[�Y����
        Clear = 1 << 5, //�N���A
        Failed = 1 << 6, //���s
    }

    void Start()
    {
        //***�v���C���[��UI�ؑ�***
        _p1SpriteRenderer = _player1.GetComponent<SpriteRenderer>();
        _p2SpriteRenderer = _player2.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (state.HasFlag(GameStatus.Battle) && !state.HasFlag(GameStatus.Pause))
        {
            _time -= Time.deltaTime;
            _timeText.text = _time.ToString("D2");
        }
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
