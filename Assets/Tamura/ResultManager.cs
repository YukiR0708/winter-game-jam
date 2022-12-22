using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultManager : MonoBehaviour
{
    GameManager _gameManager;
    StackMochiManager _stackMochiManager;
    bool _isShownResult = false;
    [SerializeField, Header("�݂�����ǂ̂��炢��ɏo�������邩")] float _orangeRange = 10;
    [SerializeField, Header("�݂���")] GameObject _orange;
    [SerializeField, Header("�N���A���̉��")] GameObject _clear;
    [SerializeField, Header("���s���̉��")] GameObject _failed;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _stackMochiManager = FindObjectOfType<StackMochiManager>();
    }

    void Update()
    {

        if (!_isShownResult)
        {

            if (_gameManager.state.HasFlag(GameManager.GameStatus.Clear))
            {
                OrangeFall(_clear);
                //�N���A�����Ƃ��̂��
            }
            else if (_gameManager.state.HasFlag(GameManager.GameStatus.Failed))
            {
                OrangeFall(_failed);
                //���s�����Ƃ��̂��
            }

        }

    }

    /// <summary>�݂��񂪏ォ��~���Ă���</summary>
    private IEnumerator OrangeFall(GameObject result)
    {
        //��ԏ�ɐς�ł������������Ă��āA����̏�ɏo��������
        GameObject orange = Instantiate(_orange, new Vector2(_stackMochiManager.LastStackMochi.transform.position.x, _stackMochiManager.LastStackMochi.transform.position.y + _orangeRange), Quaternion.identity);
        //���̌�A���̂����̏�ɂ������Ƃ݂��񂪗����Ă���
        yield return orange.transform.DOMoveY(-_orangeRange, 5).SetAutoKill().WaitForCompletion();
        result.SetActive(true); //�������A�j���[�V������������
    }
}
