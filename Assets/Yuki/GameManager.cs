using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //***�v���C���[��UI�ؑ֊֌W***
    [SerializeField] GameObject _player1 = default;
    [SerializeField] GameObject _player2 = default;
    [Tooltip("1P�̃X�v���C�g�����_���[")] SpriteRenderer _p1SpriteRenderer = default;
    [Tooltip("2P�̃X�v���C�g�����_���[")] SpriteRenderer _p2SpriteRenderer = default;

    // Start is called before the first frame update
    void Start()
    {
        //***�v���C���[��UI�ؑ�***
        _p1SpriteRenderer = _player1.GetComponent<SpriteRenderer>();
        _p2SpriteRenderer = _player2.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerChange(bool player)
    {
        //***�v���C���[��UI�ؑ�***
        if (player)//1P��������
        {
            _p1SpriteRenderer.color = new Color(255, 255, 255); //1P���邭����
            _p2SpriteRenderer.color = new Color(130, 130, 130); //2P�Â�����
        }
        else
        {
            //2P��������
            _p2SpriteRenderer.color = new Color(255, 255, 255); //2P���邭����
            _p1SpriteRenderer.color = new Color(130, 130, 130); //1P�Â�����
        }
    }
}
