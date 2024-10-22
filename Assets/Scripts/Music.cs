using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private List<MusicData> musiclist = new List<MusicData>();

    int number = 0;

    private MusicData curMusic;
    
    //���� ���� �� �������� ���� �뷡 ����
    private void Start()
    {
        number = Random.Range(0, musiclist.Count); 
        curMusic = musiclist[number];
        GameManager.Instance.GameMusic(curMusic); 
    }

    //�뷡 ����Ʈ ���� �뷡 ����
    public void PreviousMusic()
    {
        if(number > 0 && (GameManager.Instance.curState == GameState.Ready || GameManager.Instance.curState == GameState.End))
        {
            number--;
            curMusic = musiclist[number];
            GameManager.Instance.GameMusic(curMusic);
        } 
    }

    //�뷡 ����Ʈ ���� �뷡 ����
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
