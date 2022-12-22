using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MochiInstate : MonoBehaviour
{
    [SerializeField, Header("�o���݂̍��v��")] int _mochiNum;
    [SerializeField] GameObject[] _mochi;
    [SerializeField]List<GameObject> _mochis = new List<GameObject>();
    [SerializeField, Header("1P�̖݂̏o���ꏊ�E���͂̂Ƃ��͂��̏o���ꏊ�����g��")] Transform _onePpos;
    [SerializeField, Header("2P�̖݂̏o���ꏊ")] Transform _twoPpos;
    [SerializeField, Header("�c��̂��݂������ǂ�����UIText")] Text _mochiCountText;
    /// <summary>�o���݂̃C���f�b�N�X</summary>
    int _index = 0;
    /// <summary>�o���݂̃C���f�b�N�X</summary>
    int _index2 = 0;
    GameManager _gameManager;

    bool _isMochiIn = false;
    /// <summary>True�̎��A�ݏ������Ă���EFalse�̎��A�݂��u���I�����</summary>
    public bool IsMochiIn { get { return _isMochiIn; } set { _isMochiIn = value;} }
    

   
    // Start is called before the first frame update
    void Start()
    {
        IsMochiIn = false;
        _gameManager = FindObjectOfType<GameManager>();
        _mochiNum = FindObjectOfType<SceneChange>().Purpose;
        //���X�g�ɑO�����ďo���݂�S�ē���Ă���
        for (var i = 0; i < _mochiNum; i++)
        {
            int n = Random.Range(0, _mochi.Length);
            _mochis.Add(_mochi[n]);
        }
        _index = 0;
        _index2 = 0;
        
        if(_gameManager.state == GameManager.GameStatus.Kyoryoku)
        {
            _mochiCountText.text = $"{_mochiNum}";
        }
    }

    private void Update()
    {
        if (_index == _mochiNum && !IsMochiIn)
        {
            _gameManager.state &= ~GameManager.GameStatus.Kyoryoku;
            _gameManager.state = _gameManager.state | GameManager.GameStatus.Clear;
        }
    }

    public GameObject OneP()
    {
        GameObject go = Instantiate(_mochis[_index], _onePpos.position, Quaternion.identity);
        IsMochiIn = true;
        _index++;
        if (_gameManager.state == GameManager.GameStatus.Kyoryoku)
        {
            _mochiCountText.text = $"{_mochiNum - _index}";
        }
        Mochi mochi = go.GetComponent<Mochi>();
        mochi.MochiOrder = _index;
        mochi.Player = !mochi.Player;
        _gameManager.PlayerChange(mochi.Player);
        return go;
    }

    public GameObject SecoundP()
    {
        GameObject go = Instantiate(_mochis[_index2], _twoPpos.position, Quaternion.identity);
        _index2++;
        Mochi mochi = go.GetComponent<Mochi>();
        mochi.MochiOrder = _index2;
        return go;
    }

    
}
