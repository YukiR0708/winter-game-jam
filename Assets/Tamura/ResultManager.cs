using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    GameManager _gameManager;
    bool _isShownResult = false;
    [SerializeField, Header("�݂���")] GameObject _orange;

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
                //�N���A�����Ƃ��̂��
            }
            else if (_gameManager.state.HasFlag(GameManager.GameStatus.Failed))
            {
                OrangeFall();
                //���s�����Ƃ��̂��
            }

        }

    }

    /// <summary>�݂��񂪏ォ��~���Ă���</summary>
    private void OrangeFall()
    {
        //��ԏ�ɐς�ł������������Ă��āA����̏�ɏo��������
        //���̌�A���̂����̏�ɂ������Ƃ݂��񂪗����Ă���
        _isShownResult = true;
    }

    /// <summary>�݂��񂪏ォ��~���Ă���</summary>
    private IEnumerator OrangeFall(GameObject result)
    {
        //��ԏ�ɐς�ł������������Ă��āA����̏�ɏo��������
        //���̌�A���̂����̏�ɂ������Ƃ݂��񂪗����Ă���
        //�������Ă����܂ő҂�
        yield return new WaitForSeconds(1.0f);
        result.SetActive(true); //�������A�j���[�V������������
    }
}
