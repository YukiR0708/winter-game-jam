using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    GameManager _gameManager;
    bool _isShownResult = false;
    [SerializeField, Header("みかん")] GameObject _orange;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if (!_isShownResult)
        {

            if (_gameManager.state.HasFlag(GameManager.GameStatus.Clear))
            {
                OrangeFall();
                //クリアしたときのやつ
            }
            else if (_gameManager.state.HasFlag(GameManager.GameStatus.Failed))
            {
                OrangeFall();
                //失敗したときのやつ
            }

        }

    }

    /// <summary>みかんが上から降ってくる</summary>
    private void OrangeFall()
    {
        //一番上に積んであるもちを取ってきて、それの上に出現させる
        //その後、そのもちの上にゆっくりとみかんが落ちていく
        _isShownResult = true;
    }

    /// <summary>みかんが上から降ってくる</summary>
    private IEnumerator OrangeFall(GameObject result)
    {
        //一番上に積んであるもちを取ってきて、それの上に出現させる
        //その後、そのもちの上にゆっくりとみかんが落ちていく
        //↓落ちていくまで待つ
        yield return new WaitForSeconds(1.0f);
        result.SetActive(true); //ここもアニメーションさせたい
    }
}
