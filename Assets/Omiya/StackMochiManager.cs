using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StackMochiManager : MonoBehaviour
{
    //�V���O���g��
    static StackMochiManager _instance;

    public static StackMochiManager Instance { get { return _instance; } }

    GameObject _targetMochi;
    Rigidbody2D _targetMochiRb;
    Mochi _targetMochiMochi;
    [SerializeField] GameObject _mainCamera;
    [SerializeField, Tooltip("MochiInstate�X�N���v�g")] MochiInstate _mochiInstate;
    [SerializeField, Header("�ς��U����")] private List<GameObject> _stackedMochiList = new List<GameObject>();
    public List<GameObject> StackedMochiList { get { return _stackedMochiList; } }
    [Tooltip("�Ō�ɐς܂ꂽ�U")] private GameObject _lastStackMochi;
    [SerializeField,Tooltip("�ς܂ꂽ�U�̐�")] IntReactiveProperty _stackMochiCount;
    public GameObject LastStackMochi { get { return _lastStackMochi; } }

    void Awake()
    {
        //�V���O���g���̏���
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
        //_stackmochiCount�̒l���ω�������Ă΂��
        _stackMochiCount.Subscribe(m =>
        {
            //_lastStackMochi��Update����a
            _mainCamera.transform.position = new Vector2(_mainCamera.transform.position.x, _stackedMochiList[m - 1].transform.position.y);
        }).AddTo(this);

        _targetMochi = _mochiInstate.OneP();
        _targetMochiRb = _targetMochi.GetComponent<Rigidbody2D>();
        _targetMochiMochi = _targetMochi.GetComponent<Mochi>();
        _lastStackMochi = _targetMochi;
    }

    void Update()
    {
        if (_targetMochiMochi.Otosu && _targetMochiRb.velocity.magnitude == 0)
        {
            Debug.Log("�u����");
            //���X�g�ɒǉ�
            _stackedMochiList.Add(_targetMochi);
            //���X�g�ɒǉ������ŐV�̖݂�_lastStackMochi�Ɋi�[����
            _lastStackMochi = _targetMochi;
        }
    }

    public void TargetChange()
    {
        _mochiInstate.IsMochiIn = false;
        _targetMochi = _mochiInstate.OneP();
        _targetMochiRb = _targetMochi.GetComponent<Rigidbody2D>();
        _targetMochiMochi = _targetMochi.GetComponent<Mochi>();
    }
}
