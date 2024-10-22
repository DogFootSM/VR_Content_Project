using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
     
    public static GameManager Instance;
    public GameState curState = GameState.Ready;

    private Dictionary<string, int> musicHighScore = new Dictionary<string, int>(); 


    private int score = 0;
    public int Score { get { return score; } set { score = value; } }

    private MusicData musicData;
    private float elapsedTime = 0f;

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

    private void Update()
    {
        
        if(curState == GameState.Start)
        {
            elapsedTime += Time.deltaTime;
             
            //�뷡�� ����ǰ� 3�� �� ���� ���� ���� ����
            if(elapsedTime > musicData.audioClip.length + 3)
            {
                curState = GameState.End;

                //���� ���� �� �ְ� ���� ������Ʈ
                UIManager.Instance.HighScoreTextUpdate(musicData.highScore);
            } 
        } 

        HighScoreCompare();

    }

    /// <summary>
    /// �ְ� ���� �� ����
    /// </summary>
    public void HighScoreCompare()
    {
        if(score > musicData.highScore)
        {
            musicData.highScore = score; 
        }
    }


    /// <summary>
    /// ���� ���� ��ư Ŭ�� ����
    /// </summary>
    public void GameStart()
    {  
        if(curState == GameState.Ready || curState == GameState.End)
        {   
            curState = GameState.Start;
            SoundManager.Instance.PlayBGM(musicData.audioClip);
        }
        else if(curState == GameState.Start)
        {
            curState = GameState.End;
        }

    } 
 
    /// <summary>
    /// �뷡 ���� �޾ƿͼ� UI �� Clip ����
    /// </summary>
    /// <param name="music">�뷡 Data</param>
    public void GameMusic(MusicData music)
    {
        UIManager.Instance.SetMusicInfo(music); 
        SoundManager.Instance.SetAudioClip(music.audioClip);
        musicData = music;  
    }
  
}
