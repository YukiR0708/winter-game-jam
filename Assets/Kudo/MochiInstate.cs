using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiInstate : MonoBehaviour
{
    [SerializeField, Header("出す餅の合計数")] int _mochiNum;
    [SerializeField] GameObject[] _mochi;
    List<GameObject> _mochis = new List<GameObject>();
    [SerializeField, Header("1Pの餅の出現場所・協力のときはこの出現場所だけ使う")] Transform _onePpos;
    [SerializeField, Header("2Pの餅の出現場所")] Transform _twoPpos;
    /// <summary>出す餅のインデックス</summary>
    int _index = 0;
    /// <summary>出す餅のインデックス</summary>
    int _index2 = 0;
    GameManager _gameManager;

    bool _isMochiIn = false;
    /// <summary>Trueの時、餅召喚してある・Falseの時、餅が置き終わった</summary>
    public bool IsMochiIn { get { return _isMochiIn; } set { _isMochiIn = value;} }
    

   
    // Start is called before the first frame update
    void Start()
    {
        IsMochiIn = false;
        _gameManager = FindObjectOfType<GameManager>();
        _mochiNum = FindObjectOfType<SceneChange>().Purpose;
        //リストに前もって出す餅を全て入れておく
        for (var i = 0; i < _mochiNum; i++)
        {
            int n = Random.Range(0, _mochi.Length);
            _mochis.Add(_mochi[n]);
        }
        _index = 0;
        _index2 = 0;
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
        GameObject go = Instantiate(_mochi[_index], _onePpos.position, Quaternion.identity);
        IsMochiIn = true;
        _index++;
        Mochi mochi = go.GetComponent<Mochi>();
        mochi.Player = !mochi.Player;
        _gameManager.PlayerChange(mochi.Player);
        return go;
    }

    public GameObject SecoundP()
    {
        GameObject go = Instantiate(_mochi[_index2], _twoPpos.position, Quaternion.identity);
        _index2++;
        return go;
    }
}
