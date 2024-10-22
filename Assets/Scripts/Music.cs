using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private List<MusicData> musiclist = new List<MusicData>();

    int number = 0;

    private MusicData curMusic;
    
    //게임 시작 시 랜덤으로 임의 노래 선택
    private void Start()
    {
        number = Random.Range(0, musiclist.Count); 
        curMusic = musiclist[number];
        GameManager.Instance.GameMusic(curMusic); 
    }

    //노래 리스트 이전 노래 선택
    public void PreviousMusic()
    {
        if(number > 0 && (GameManager.Instance.curState == GameState.Ready || GameManager.Instance.curState == GameState.End))
        {
            number--;
            curMusic = musiclist[number];
            GameManager.Instance.GameMusic(curMusic);
        } 
    }

    //노래 리스트 다음 노래 선택
    public void NextMusic()
    {
        if (number < musiclist.Count-1 && (GameManager.Instance.curState == GameState.Ready || GameManager.Instance.curState == GameState.End))
        {
            number++;
            curMusic = musiclist[number];
            GameManager.Instance.GameMusic(curMusic);
        }
    }




}
