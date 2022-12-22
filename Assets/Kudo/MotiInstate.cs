using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiInstate : MonoBehaviour
{
    [SerializeField, Header("�o���݂̍��v��")] int motiNum;
    GameObject[] moti;
    List<GameObject> motis = new List<GameObject>();
    [SerializeField, Header("1P�̖݂̏o���ꏊ�E���͂̂Ƃ��͂��̏o���ꏊ�����g��")] Transform OnePpos;
    [SerializeField, Header("2P�̖݂̏o���ꏊ")] Transform TwoPpos;
    int count = 0;
    int count2 = 0;
    GameManager gameManager;
    public bool isMochiIn = false;
    

   
    // Start is called before the first frame update
    void Start()
    {
        isMochiIn = false;
        gameManager = FindObjectOfType<GameManager>();
        //FindObjectOfType<>
        //���X�g�ɑO�����ďo���݂�S�ē���Ă���
        for (var i = 0; i < motiNum; i++)
        {
            int n = Random.Range(0, moti.Length);
            motis.Add(moti[n]);
        }
        count = 0;
        count2 = 0;
    }

    private void Update()
    {
        if (count == motiNum && !isMochiIn)
        {
            gameManager.state &= ~GameManager.GameStatus.Kyoryoku;
            gameManager.state = gameManager.state | GameManager.GameStatus.Clear;
        }
    }

    public GameObject OneP()
    {
        GameObject go = Instantiate(moti[count], OnePpos.position, Quaternion.identity);
        isMochiIn = true;
        count++;
        Mochi mochi = go.GetComponent<Mochi>();
        mochi.Player = !mochi.Player;
        return go;
    }

    public GameObject SecoundP()
    {
        GameObject go = Instantiate(moti[count2], TwoPpos.position, Quaternion.identity);
        
        
        count2++;
        return go;
    }
}
