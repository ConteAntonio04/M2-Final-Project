using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] Hero A, B;
    Stats ATotalStats;
    Stats BTotalStats;
    int CoinFlip;

    private void Start()
    {
        ATotalStats = Stats.Sum(A.GetBaseStats(), A.GetWeapon().GetStats());
        BTotalStats = Stats.Sum(B.GetBaseStats(), B.GetWeapon().GetStats());
        CoinFlip = Random.Range(0, 2);
    }
    void Update()
    {
        if (!A.IsAlive() || !B.IsAlive()) return;

        if (ATotalStats.spd == BTotalStats.spd && CoinFlip == 0)
        {
            GameFormulas.Fight(A, B, ATotalStats, BTotalStats);
        }
        else if (ATotalStats.spd == BTotalStats.spd && CoinFlip == 1)
        {
            GameFormulas.Fight(B, A, BTotalStats, ATotalStats);
        }
        else if (ATotalStats.spd > BTotalStats.spd)
        {
            GameFormulas.Fight(A, B, ATotalStats, BTotalStats);
        }
        else if (ATotalStats.spd < BTotalStats.spd)
        {
            GameFormulas.Fight(B, A, BTotalStats, ATotalStats);
        }
    }
    
}
