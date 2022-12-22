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
    [SerializeField] float _maxSpeed = 3.0f;
    [SerializeField] bool _otosu = false;
    /// <summary>Trueのとき落としてる,Flaseの時まだ上にいる</summary>
    public bool Otosu { get => _otosu; set => _otosu = value; }
    [SerializeField] float _time = 0;
    private float _distance;
    Rigidbody2D _rb;
    [SerializeField] float _gravityScale = 1.0f;
    bool _player = false;
    Vector3 _velocity;
    /// <summary>Trueの時P1,Falseの時P2</summary>
    public bool Player { get => _player; set => _player = value; }
    [SerializeField] int _mochiOrder;
    public int MochiOrder { get => _mochiOrder; set => _mochiOrder = value; }
    void Start()
    {
        FindObjectOfType<Pause>().PauseAction += PauseKun;
        FindObjectOfType<Pause>().ResumeAction += ResumeKun;
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        //二点間の距離を代入
        _distance = Vector3.Distance(_startMarker.position, _endMarker.position) / 2;
        gameObject.transform.position = (_startMarker.position + _endMarker.position) / 2;
    }
    void Update()
    {
        if (!_otosu)
        {
            LRMove();
        }
        PlayerChange();
    }
    void PauseKun()
    {
        _velocity = _rb.velocity;
        _rb.velocity = new Vector2(0, 0);
        _rb.gravityScale = 0;
    }
    void ResumeKun()
    {
        _rb.velocity = _velocity;
        _velocity = new Vector2(0, 0);
        _rb.velocity = new Vector3(0, 0.005f, 0);
        _rb.gravityScale = _gravityScale;
    }
    /// <summary>プレイヤーの切り替えで入力受け取りが違うようにした場所 </summary>
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
        _rb.velocity = new Vector3(0, 0.005f, 0);
        _rb.gravityScale = _gravityScale;
    }
    /// <summary>左右移動する君</summary>
    void LRMove()
    {
        float m_speed = _speed + 0.1f * _mochiOrder;
        if (m_speed > _maxSpeed)
        {
            m_speed = _maxSpeed;
        }
        _time += Time.deltaTime * m_speed;
        float sin = Mathf.Sin(_time);
        this.transform.position = new Vector3(sin * _distance, this.gameObject.transform.position.y);
    }
}
