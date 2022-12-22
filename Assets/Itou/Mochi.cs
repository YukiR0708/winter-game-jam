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
    /// <summary>True�̂Ƃ����Ƃ��Ă�,Flase�̎��܂���ɂ���</summary>
    public bool Otosu { get => _otosu; set => _otosu = value; }
    [SerializeField] float _time = 0;
    private float _distance;
    Rigidbody2D _rb;
    [SerializeField] float _gravityScale = 1.0f;
    bool _player = false;
    Vector3 _volocity;
    /// <summary>True�̎�P1,False�̎�P2</summary>
    public bool Player { get => _player; set => _player = value; }
    void Start()
    {
        FindObjectOfType<Pause>().PauseAction += PauseKun;
        FindObjectOfType<Pause>().ResumeAction += ResumeKun;
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        //��_�Ԃ̋�������
        _distance = Vector3.Distance(_startMarker.position, _endMarker.position) / 2;
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
    void PauseKun()
    {
        _volocity = _rb.velocity;
        _rb.velocity = new Vector2(0, 0);
        _rb.gravityScale = 0;
    }
    void ResumeKun()
    {
        _rb.velocity = _volocity;
        _volocity = new Vector2(0, 0);
        _rb.gravityScale = _gravityScale;
    }
    void OnDestroy()
    {
        FindObjectOfType<Pause>().PauseAction -= PauseKun;
        FindObjectOfType<Pause>().ResumeAction -= ResumeKun;
    }
    /// <summary>�v���C���[�̐؂�ւ��œ��͎󂯎�肪�Ⴄ�悤�ɂ����ꏊ </summary>
    void PlayerChange()
    {
        if (Player)
        {
            if (Input.GetButtonDown(_p1ButtonName))
            {
                _otosu = true;
                Otoshimasu();
            }
        }
        else
        {
            if (Input.GetButtonDown(_p2ButtonName))
            {
                _otosu = true;
                Otoshimasu();
            }
        }
    }
    void Otoshimasu()
    {
        _rb.gravityScale = _gravityScale;
    }
    /// <summary>���E�ړ�����N</summary>
    void LRMove()
    {
        float sin = Mathf.Sin(_time);
        this.transform.position = new Vector3(sin * _distance, this.gameObject.transform.position.y);
    }
}
