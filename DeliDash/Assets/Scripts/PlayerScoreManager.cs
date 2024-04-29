using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    public static PlayerScoreManager Instance { get; private set; }

    public int HP { get; private set; }
    public int TrafficViolationScore { get; private set; }
    public int maxHP=5;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            HP=maxHP;
            TrafficViolationScore=0;
        }
    }

    public void AddHP(int amount)
    {
        HP += amount;
        Debug.Log($"HP updated: {HP}");
    }

    public void DeductHP(int amount)
    {
        HP -= amount;
        Debug.Log($"HP updated: {HP}");
    }

    public void AddTrafficViolationScore(int amount)
    {
        TrafficViolationScore +=amount;
        Debug.Log($"TrafficViolationScore updated: {TrafficViolationScore}");
    }
}
