using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("스코어 관련 UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image timeGraph;
    [SerializeField] private TextMeshProUGUI timeText;

    [Header("노래 선택 관련 UI")]
    [SerializeField] private RawImage coverImage;
    [SerializeField] private TextMeshProUGUI musicTitle;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI runTime;
    [SerializeField] private TextMeshProUGUI startText;


    [SerializeField] private TextMeshProUGUI preListening;

    [SerializeField] private GameObject scoreCanvas;

    public Action OnScoreUI;
    private Coroutine activeCo;

    private float elapsedTime;
    private float totalTime;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        OnScoreUI = ScoreTextUpdate;

    }

    private void Update()
    { 
        UIActive();
        PreListeningText();
    }

    /// <summary>
    /// 게임 상태에 따라 UI Active 상태 변경
    /// </summary>
    public void UIActive()
    {
        if (GameManager.Instance.curState == GameState.Start)
        { 
            scoreCanvas.SetActive(true);
            Timer();
            startText.text = "Stop";
        }
        else if(GameManager.Instance.curState == GameState.End)
        {
            activeCo = StartCoroutine(ActiveCoroutine());
            startText.text = "Start";
        }

    }

    /// <summary>
    /// 미리 듣기 문구 업데이트
    /// </summary>
    public void PreListeningText()
    {
        if (SoundManager.Instance.IsPlaying)
        {
            preListening.text = "Stop";
        }
        else
        {
            preListening.text = "Play";
        }
    }


    /// <summary>
    /// 노래 재생 타이머
    /// </summary>
    public void Timer()
    {
        timeGraph.fillAmount = SoundManager.Instance.CurPlayTime / totalTime;

        if (SoundManager.Instance.IsPlaying)
        {
            elapsedTime -= Time.deltaTime;
        }

        float minute = (int)elapsedTime / 60;
        float second = MathF.Round((int)elapsedTime % 60);

        if (second < 10)
        {
            timeText.text = minute.ToString() + " : " + "0" + second.ToString();
        }
        else
        {
            timeText.text = minute.ToString() + " : " + second.ToString();
        }

    }


    /// <summary>
    /// 스코어 업데이트
    /// </summary>
    public void ScoreTextUpdate()
    {
        scoreText.text = "Score : " + GameManager.Instance.Score.ToString();
    }

    public void HighScoreTextUpdate(int highScore)
    {
        this.highScore.text = "High Score : " + highScore.ToString();
    }


    /// <summary>
    /// 노래 정보 업데이트
    /// </summary>
    /// <param name="music"></param>
    public void SetMusicInfo(MusicData music)
    {
        coverImage.texture = music.coverImage.texture;
        musicTitle.text = music.musicTitle;
        highScore.text = "High Score : " + music.highScore.ToString();

        float time = music.audioClip.length;
        float minute = (int)time / 60;
        float second = MathF.Round(time % 60);

        runTime.text = "Time : " + minute.ToString() + " 분 " + second + " 초";
        elapsedTime = time;
        totalTime = time;
    }
 
    private IEnumerator ActiveCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        scoreCanvas.SetActive(false);

    }

}
