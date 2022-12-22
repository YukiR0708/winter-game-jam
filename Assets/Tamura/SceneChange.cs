using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>�V�[�����ړ������܂��@�{�^���Ƃ��ɂ��Ă�������</summary>
public class SceneChange : MonoBehaviour
{
    //�ڕW�̂����̐�
    static int _purpose = 10;
    /// <summary>���̃X�e�[�W�̖ڕW������</summary>
    public int Purpose { get => _purpose; }
    [SerializeField, Header("���̓�Փx�̖ڕW�l")] int _levelPurpose = 10;

    /// <summary>�^�C�g���V�[�������[�h����</summary>
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    /// <summary>���̓V�[�������[�h����</summary>
    public void LoadKyoryokuScene()
    {
        _purpose = _levelPurpose;
        SceneManager.LoadScene("Kyoryoku");
    }

    /// <summary>�o�g���V�[�������[�h����</summary>
    public void LoadBattleScene()
    {
        SceneManager.LoadScene("Battle");
    }

}
