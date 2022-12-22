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
    [SerializeField] float _time = 0;
    private float _distance;
    Rigidbody2D _rb;
    [SerializeField] float _gravityScale = 1.0f;
    bool _player = false;
    /// <summary>Trueの時P1,Falseの時P2</summary>
    public bool Player { get => _player; set => _player = value; }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        //二点間の距離を代入
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
        _rb.gravityScale = _gravityScale;
    }
    /// <summary>左右移動する君</summary>
    void LRMove()
    {
        float sin = Mathf.Sin(_time);
        this.transform.position = new Vector3(sin * _distance, this.gameObject.transform.position.y);
    }
}
