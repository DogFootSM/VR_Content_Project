using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI songText;

    public Action OnScoreUI;

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
        OnScoreUI = ScoreTextUpdate;
    }
 

    public void ScoreTextUpdate()
    {
        scoreText.text = "Score : " + GameManager.Instance.Score.ToString();
    }

    


}
