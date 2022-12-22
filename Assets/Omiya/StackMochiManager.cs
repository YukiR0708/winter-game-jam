using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StackMochiManager : MonoBehaviour
{
    //シングルトン
    static StackMochiManager _instance;

    public static StackMochiManager Instance { get { return _instance; } }

    [SerializeField,Header("積んだ餠たち")]
    List<GameObject> _stackedMochiList = new List<GameObject>();

    [Tooltip("最後に積まれた餠")]
    private GameObject _lastStackMochi;
    public GameObject LastStackMochi { get { return _lastStackMochi; } }

    [Tooltip("積まれた餠の数")]
    IntReactiveProperty _stackMochiCount;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        UpdateLastMochi();
    }

    /// <summary>一番上の餠を変数に入れる</summary>
    void UpdateLastMochi()
    {
        _stackMochiCount.Subscribe(m =>
        {
            _lastStackMochi = _stackedMochiList[m - 1];
        }).AddTo(this);
    }
}
