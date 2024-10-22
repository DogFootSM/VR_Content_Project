using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private Button preListenButton;

    private Coroutine musicCo;
    private bool isPlaying;
    public bool IsPlaying { get { return isPlaying; } }

    private float curPlayTime;
    public float CurPlayTime { get { return curPlayTime; } }

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

        //Volume 슬라이더 이벤트
        volumeSlider.onValueChanged.AddListener(SetBGMVolume);

    }

    private void Start()
    {
        //미리 듣기 버튼 이벤트
        preListenButton.onClick.AddListener(PreListening);
    }

    private void Update()
    {
        
        if(GameManager.Instance.curState == GameState.End)
        {
            //노래 재생 코루틴 중지
            if (musicCo != null)
            {
                StopCoroutine(musicCo);
                musicCo = null;
            }
            //재생중인 노래 중지
            bgmSource.Stop();
        }
        
        //현재 진행중인 노래 시간대
        curPlayTime = bgmSource.time;

        //노래 재생 여부
        isPlaying = bgmSource.isPlaying; 
    }


    /// <summary>
    /// 노래의 재생 길이
    /// </summary>
    /// <returns>노래 재생 길이 반환</returns>
    public float GetPlayTime()
    {
        return bgmSource.clip.length;
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", volume * 20f);

    }
    
    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;

        if(musicCo == null)
        {
            musicCo = StartCoroutine(PlayMusic());
        }

    }

    /// <summary>
    /// 게임 시작 후 N 초 뒤 노래 재생 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayMusic()
    {
        float musicTimer = 3f;
        WaitForSeconds wait = new WaitForSeconds(musicTimer);

        yield return wait; 
        bgmSource.Play(); 

    }

    /// <summary>
    /// 노래 미리 듣기 Clip 설정 
    /// </summary>
    /// <param name="clip"></param>
    public void SetAudioClip(AudioClip clip)
    {
        bgmSource.clip = clip;
    }

    /// <summary>
    /// 미리 듣기 재생/중지 동작
    /// </summary>
    public void PreListening()
    { 
        if (bgmSource.isPlaying)
        {
            bgmSource.Stop();
            TextMeshProUGUI stop = preListenButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            stop.text = "Play";
        }
        else
        {
            bgmSource.Play();
            TextMeshProUGUI play = preListenButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            play.text = "Stop";
        }
    }

}
