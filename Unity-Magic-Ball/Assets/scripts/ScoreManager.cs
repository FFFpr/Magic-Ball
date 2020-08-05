using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int winScore;
    int ownScore;
    int enemyScore;
    bool isFarLaunch;
    public int farLaunchScore;
    public int shortLaunchScore;
    public static ScoreManager singleton;

    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        isFarLaunch = true;
        ownScore = 0;
        enemyScore = 0;
        winScore = 100;
    }
    private void Update()
    {
        if (ownScore >= winScore)
        {
            isFarLaunch = false;
            //TODO...
            ownScore = 0;
            enemyScore = 0;
            Debug.Log("You Win!");
        }
        if (enemyScore >= winScore)
        {
            isFarLaunch = false;
            //TODO...
            ownScore = 0;
            enemyScore = 0;
            Debug.Log("You Lost.");
        }
    }
    public void SetWinScore(int value)
    {
        winScore = value;
    }
    public void SetIsFarLaunch(bool value)
    {
        isFarLaunch = value;
    }
    public void WeScore()
    {
        if (isFarLaunch)
            ownScore += farLaunchScore;
        else 
            ownScore += shortLaunchScore;
    }
    public void OpponentScore()
    {
        if (isFarLaunch)
            enemyScore += farLaunchScore;
        else
            enemyScore += shortLaunchScore;
    }
}
