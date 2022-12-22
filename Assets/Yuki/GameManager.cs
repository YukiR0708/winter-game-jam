using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //***プレイヤーのUI切替関係***
    [SerializeField] GameObject _player1 = default;
    [SerializeField] GameObject _player2 = default;
    [Tooltip("1Pのスプライトレンダラー")] SpriteRenderer _p1SpriteRenderer = default;
    [Tooltip("2Pのスプライトレンダラー")] SpriteRenderer _p2SpriteRenderer = default;

    // Start is called before the first frame update
    void Start()
    {
        //***プレイヤーのUI切替***
        _p1SpriteRenderer = _player1.GetComponent<SpriteRenderer>();
        _p2SpriteRenderer = _player2.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

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
