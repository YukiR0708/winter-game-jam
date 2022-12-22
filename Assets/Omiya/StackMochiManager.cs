using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StackMochiManager : MonoBehaviour
{

    //シングルトン
    static StackMochiManager _instance;

    public static StackMochiManager Instance { get { return _instance; } }

    [SerializeField, Header("積んだ餠たち")]
    List<GameObject> _stackedMochiList = new List<GameObject>();

    [Tooltip("最後に積まれた餠")]
    private GameObject _lastStackMochi;
    public GameObject LastStackMochi { get { return _lastStackMochi; } }

    [Tooltip("積まれた餠の数")]
    IntReactiveProperty _stackMochiCount;
    //MochiInstateスクリプト
    [SerializeField] MochiInstate _mochiInstate;
    //Mochiスクリプト

    GameObject _targetMochi;
    Rigidbody2D _targetMochiRb;
    Mochi _targetMochiMochi;


    void Awake()
    {
        //シングルトンの処理
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _targetMochi = _mochiInstate.OneP();
        _targetMochiRb = _targetMochi.GetComponent<Rigidbody2D>();
        _targetMochiMochi = _targetMochi.GetComponent<Mochi>();
        _lastStackMochi = _targetMochi;
    }

    void Update()
    {
        if (_targetMochiRb.velocity.magnitude == 0 && _targetMochiMochi.Otosu)
        {
            Debug.Log("置けた");
            _stackedMochiList.Add(_targetMochi);
            _lastStackMochi = _targetMochi;
            _mochiInstate.IsMochiIn = false;
            _targetMochi = _mochiInstate.OneP();
            _targetMochiRb = _targetMochi.GetComponent<Rigidbody2D>();
            _targetMochiMochi = _targetMochi.GetComponent<Mochi>();
        }
    }

    ///// <summary>一番上の餠を変数に入れる</summary>
    //void UpdateLastMochi()
    //{
    //    //_stackmochiCountの値が変化したら呼ばれる
    //    _stackMochiCount.Subscribe(m =>
    //    {
    //        //_lastStackMochiをUpdateするa
    //        _lastStackMochi = _stackedMochiList[m - 1];
    //    }).AddTo(this);
    //}
}
