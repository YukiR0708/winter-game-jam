using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StackMochiManager : MonoBehaviour
{
    //ƒVƒ“ƒOƒ‹ƒgƒ“
    static StackMochiManager _instance;

    public static StackMochiManager Instance { get { return _instance; } }

    [SerializeField,Header("Ο‚ρ‚ΎιU‚½‚Ώ")]
    List<GameObject> _stackedMochiList = new List<GameObject>();

    [Tooltip("Εγ‚ΙΟ‚ά‚κ‚½ιU")]
    private GameObject _lastStackMochi;
    public GameObject LastStackMochi { get { return _lastStackMochi; } }

    [Tooltip("Ο‚ά‚κ‚½ιU‚Μ”")]
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

    /// <summary>κ”Τγ‚ΜιU‚π•Ο”‚Ι“ό‚κ‚ι</summary>
    void UpdateLastMochi()
    {
        _stackMochiCount.Subscribe(m =>
        {
            _lastStackMochi = _stackedMochiList[m - 1];
        }).AddTo(this);
    }
}
