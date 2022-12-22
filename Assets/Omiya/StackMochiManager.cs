using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StackMochiManager : MonoBehaviour
{
    //�V���O���g��
    static StackMochiManager _instance;

    public static StackMochiManager Instance { get { return _instance; } }

    [SerializeField,Header("�ς��U����")]
    List<GameObject> _stackedMochiList = new List<GameObject>();

    [Tooltip("�Ō�ɐς܂ꂽ�U")]
    private GameObject _lastStackMochi;
    public GameObject LastStackMochi { get { return _lastStackMochi; } }

    [Tooltip("�ς܂ꂽ�U�̐�")]
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

    /// <summary>��ԏ���U��ϐ��ɓ����</summary>
    void UpdateLastMochi()
    {
        _stackMochiCount.Subscribe(m =>
        {
            _lastStackMochi = _stackedMochiList[m - 1];
        }).AddTo(this);
    }
}
