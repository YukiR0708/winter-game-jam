using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>シーンを移動させます　ボタンとかにつけてください</summary>
public class SceneChange : MonoBehaviour
{
    //目標のもちの数
    static int _purpose = 10;
    /// <summary>そのステージの目標もち数</summary>
    public int Purpose { get => _purpose; }
    [SerializeField, Header("その難易度の目標値")] int _levelPurpose = 10;

    /// <summary>タイトルシーンをロードする</summary>
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    /// <summary>協力シーンをロードする</summary>
    public void LoadKyoryokuScene()
    {
        _purpose = _levelPurpose;
        SceneManager.LoadScene("Kyoryoku");
    }

    /// <summary>バトルシーンをロードする</summary>
    public void LoadBattleScene()
    {
        SceneManager.LoadScene("Battle");
    }

}
