using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochi : MonoBehaviour
{
    [SerializeField] Transform _startMarker;
    [SerializeField] Transform _endMarker;
    [SerializeField] float speed = 1.0F;
    [SerializeField] bool _otosu;
    [SerializeField] float _time;
    Transform _middleTransform;

    bool _player = false;
    /// <summary>
    /// True‚ÌŽžP1,False‚ÌŽžP2
    /// </summary>
    public bool Player { get => _player; set => _player = value; }
    void Start()
    {

    }
    void Update()
    {
        if (!_otosu)
        {
            LRMove();
        }
    }
    void LRMove()
    {
        _time += Time.deltaTime;
        Mathf.Sin(_time);
    }
}
