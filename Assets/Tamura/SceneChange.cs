using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //�ڕW�̂����̐�
    static int _purpose = 10;
    public int Purpose { get => _purpose; }
    [SerializeField, Header("���̓�Փx�̖ڕW�l")] int _levelPurpose = 10;

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadKyoryokuScene()
    {
        _purpose = _levelPurpose;
        SceneManager.LoadScene("Kyoryoku");
    }

    public void LoadBattleScene()
    {
        SceneManager.LoadScene("Battle");
    }

}
