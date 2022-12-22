using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    public GameStatus state = GameStatus.Title;
    //***残り時間関係***
    [SerializeField] float _time = default;
    [SerializeField] Text _timeText = default;

    //***プレイヤーのUI切替関係***
    [SerializeField] GameObject _player1 = default;
    [SerializeField] GameObject _player2 = default;
    [Tooltip("1Pのスプライトレンダラー")] SpriteRenderer _p1SpriteRenderer = default;
    [Tooltip("2Pのスプライトレンダラー")] SpriteRenderer _p2SpriteRenderer = default;


    /// <summary>現在のゲーム状態管理用</summary>
    [Flags]
    public enum GameStatus
    {
        Title = 1 << 0,  //タイトル,操作説明等 
        Kyoryoku = 1 << 1, //協力モード
        Battle = 1 << 2, //バトル
        Pause = 1 << 3, //ポーズ
        UnPause = 1 << 4,    //ポーズ解除
        Clear = 1 << 5, //クリア
        Failed = 1 << 6, //失敗
    }

    void Start()
    {
        //***プレイヤーのUI切替***
        _p1SpriteRenderer = _player1.GetComponent<SpriteRenderer>();
        _p2SpriteRenderer = _player2.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (state.HasFlag(GameStatus.Battle) && !state.HasFlag(GameStatus.Pause))
        {
            _time -= Time.deltaTime;
            _timeText.text = _time.ToString("D2");
        }
    }

    /// <summary>各もちから呼んでもらう</summary>
    /// <param name="player"></param>
    public void PlayerChange(bool player)
    {
        //***プレイヤーのUI切替***
        if (player)//1Pだったら
        {
            _p1SpriteRenderer.color = new Color(255, 255, 255); //1P明るくする
            _p2SpriteRenderer.color = new Color(130, 130, 130); //2P暗くする
        }
        else
        {
            //2Pだったら
            _p2SpriteRenderer.color = new Color(255, 255, 255); //2P明るくする
            _p1SpriteRenderer.color = new Color(130, 130, 130); //1P暗くする
        }
    }
}
