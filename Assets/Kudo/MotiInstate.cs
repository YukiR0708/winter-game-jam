using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiInstate : MonoBehaviour
{
    [SerializeField, Header("出す餅の合計数")] int motiNum;
    GameObject[] moti;
    List<GameObject> motis = new List<GameObject>();
    [SerializeField, Header("1Pの餅の出現場所・協力のときはこの出現場所だけ使う")] Transform OnePpos;
    [SerializeField, Header("2Pの餅の出現場所")] Transform TwoPpos;
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
        //リストに前もって出す餅を全て入れておく
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
