using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    //private Dictionary<노래제목, 점수>


    private int score = 0;
    public int Score { get { return score; } set { score = value; } }
 
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
 


}
