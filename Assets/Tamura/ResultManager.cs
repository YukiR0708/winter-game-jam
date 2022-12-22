using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>ゲームが終わった時に、みかん落ちてきてリザルト画面が出る</summary>
public class ResultManager : MonoBehaviour
{
    GameManager _gameManager;
    bool _isShownResult = false;
    [SerializeField, Header("みかんをどのくらい上に出現させるか")] float _orangeRange = 10;
    [SerializeField, Header("みかん")] GameObject _orange;
    [SerializeField, Header("クリア時の画面")] GameObject _clear;
    [SerializeField, Header("失敗時の画面")] GameObject _failed;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if (!_isShownResult)
        {

            //if (_gameManager.state.HasFlag(GameManager.GameStatus.Clear))
            //{
            //    //クリアしたときのやつ
            //    OrangeFall(_clear);
            //}
            //else
            if (_gameManager.state.HasFlag(GameManager.GameStatus.Failed))
            {
                //失敗したときのやつ
                OrangeFall(_failed);
            }

        }
        
    }

    /// <summary>みかんが上から降ってくる</summary>
    private IEnumerator OrangeFall(GameObject result)
    {
        _isShownResult = true;
        //一番上に積んであるもちを取ってきて、それの上に出現させる
        GameObject orange = 
            Instantiate(_orange, new Vector2(StackMochiManager.Instance.LastStackMochi.transform.position.x, StackMochiManager.Instance.LastStackMochi.transform.position.y + _orangeRange), Quaternion.identity);
        //その後、そのもちの上にゆっくりとみかんが落ちていく
        yield return orange.transform.DOMoveY(-_orangeRange, 5).SetAutoKill().WaitForCompletion();
        result.SetActive(true); //ここもアニメーションさせたい
    }
}
