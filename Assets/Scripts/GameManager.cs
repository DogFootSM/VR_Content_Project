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
             
            //노래가 종료되고 3초 뒤 게임 종료 상태 변경
            if(elapsedTime > musicData.audioClip.length + 3)
            {
                curState = GameState.End;

                //게임 종료 시 최고 점수 업데이트
                UIManager.Instance.HighScoreTextUpdate(musicData.highScore);
            } 
        } 

        HighScoreCompare();

    }

    /// <summary>
    /// 최고 점수 비교 동작
    /// </summary>
    public void HighScoreCompare()
    {
        if(score > musicData.highScore)
        {
            musicData.highScore = score; 
        }
    }


    /// <summary>
    /// 게임 시작 버튼 클릭 동작
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
    /// 노래 정보 받아와서 UI 및 Clip 설정
    /// </summary>
    /// <param name="music">노래 Data</param>
    public void GameMusic(MusicData music)
    {
        UIManager.Instance.SetMusicInfo(music); 
        SoundManager.Instance.SetAudioClip(music.audioClip);
        musicData = music;  
    }
  
}
