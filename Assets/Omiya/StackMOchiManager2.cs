using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StackMOchiManager2 : MonoBehaviour
{
    GameObject _targetMochi;
    Rigidbody2D _targetMochiRb;
    Mochi _targetMochiMochi;
    [SerializeField] GameObject _mainCamera;
    [SerializeField, Tooltip("MochiInstateスクリプト")] MochiInstate _mochiInstate;
    [SerializeField, Header("積んだ餠たち")] private List<GameObject> _stackedMochiList = new List<GameObject>();
    public List<GameObject> StackedMochiList { get { return _stackedMochiList; } }
    [Tooltip("最後に積まれた餠")] private GameObject _lastStackMochi;
    [SerializeField, Tooltip("積まれた餠の数")] IntReactiveProperty _stackMochiCount;
    public GameObject LastStackMochi { get { return _lastStackMochi; } }

    [SerializeField] int _mochiCameraMin;




    void Start()
    {
        Observable.TimerFrame(2).Subscribe(_ =>
        { }).AddTo(this);
        TakeListCount();
        //_stackmochiCountの値が変化したら呼ばれる
        _stackMochiCount.Subscribe(m =>
        {
            //_lastStackMochiをUpdateする
            if (m > _mochiCameraMin)
            {
                _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, _stackedMochiList[m - 1].transform.position.y, _mainCamera.transform.position.z);
            }
        }
            ).AddTo(this);

        _targetMochi = _mochiInstate.OneP();
        _targetMochiRb = _targetMochi.GetComponent<Rigidbody2D>();
        _targetMochiMochi = _targetMochi.GetComponent<Mochi>();
        _lastStackMochi = _targetMochi;
    }

    void Update()
    {
        if (_targetMochiMochi.Otosu && _targetMochiRb.velocity.magnitude == 0)
        {
            Debug.Log("置けた");
            //リストに追加
            _stackedMochiList.Add(_targetMochi);
            //リストに追加した最新の餅を_lastStackMochiに格納する
            _lastStackMochi = _targetMochi;
            TakeListCount();
        }
    }

    public void TargetChange()
    {
        _mochiInstate.IsMochiIn = false;
        _targetMochi = _mochiInstate.SecoundP();
        _targetMochiRb = _targetMochi.GetComponent<Rigidbody2D>();
        _targetMochiMochi = _targetMochi.GetComponent<Mochi>();
    }

    public void TakeListCount()
    {
        _stackMochiCount.Value = _stackedMochiList.Count;
    }
}
