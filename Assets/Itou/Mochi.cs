using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochi : MonoBehaviour
{
    [SerializeField] string _p1ButtonName = "Submit";
    [SerializeField] string _p2ButtonName = "Jump";
    [SerializeField] Transform _startMarker;
    [SerializeField] Transform _endMarker;
    [SerializeField] float _speed = 1.0f;
    [SerializeField] bool _otosu = false;
    [SerializeField] float _time;
    private float distance_two;
    bool _player = false;
    /// <summary>True�̎�P1,False�̎�P2</summary>
    public bool Player { get => _player; set => _player = value; }
    void Start()
    {
        //��_�Ԃ̋�������
        distance_two = Vector3.Distance(_startMarker.position, _endMarker.position) / 2;
        gameObject.transform.position = (_startMarker.position + _endMarker.position) / 2;
    }
    void Update()
    {
        _time += Time.deltaTime * _speed;
        if (!_otosu)
        {
            LRMove();
        }
        PlayerChange();
    }
    /// <summary>�v���C���[�̐؂�ւ��œ��͎󂯎�肪�Ⴄ�悤�ɂ����ꏊ </summary>
    void PlayerChange()
    {
        if (Player)
        {
            if (Input.GetButtonDown(_p1ButtonName))
            {
                _otosu = true;
            }
        }
        else
        {
            if (Input.GetButtonDown(_p2ButtonName))
            {
                _otosu = true;
            }
        }
    }
    /// <summary>
    /// ���E�ړ�����N
    /// </summary>
    void LRMove()
    {
        float sin = Mathf.Sin(_time);
        this.transform.position = new Vector3(sin * distance_two, 0);
    }
}
