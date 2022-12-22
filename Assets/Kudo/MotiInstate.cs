using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiInstate : MonoBehaviour
{
    [SerializeField] int motiNum;
    [SerializeField] GameObject[] moti;
    List<GameObject> motis = new List<GameObject>();
    [SerializeField] Transform OnePpos;
    [SerializeField] Transform TwoPpos;
    int count = 0;
    int count2 = 0;
    
    GameManager gameManager;
    Mochi mochi;
    public bool isMochiIn = false;
    public bool isMochiIn2 = false;

   
    // Start is called before the first frame update
    void Start()
    {
        isMochiIn = false;
        isMochiIn2 = false;
        
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

    public void OneP()
    {
       GameObject go = Instantiate(moti[count], OnePpos.position, Quaternion.identity);
        isMochiIn = true;
        count++;
        Mochi mochi = go.GetComponent<Mochi>();
        mochi.Player = !mochi.Player;
    }

    public void SecoundP()
    {
        Instantiate(moti[count2], TwoPpos.position, Quaternion.identity);
        isMochiIn2 = true;
        count2++;
    }
}
