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

        //Volume �����̴� �̺�Ʈ
        volumeSlider.onValueChanged.AddListener(SetBGMVolume);

    }

    private void Start()
    {
        //�̸� ��� ��ư �̺�Ʈ
        preListenButton.onClick.AddListener(PreListening);
    }

    private void Update()
    {
        
        if(GameManager.Instance.curState == GameState.End)
        {
            //�뷡 ��� �ڷ�ƾ ����
            if (musicCo != null)
            {
                StopCoroutine(musicCo);
                musicCo = null;
            }
            //������� �뷡 ����
            bgmSource.Stop();
        }
        
        //���� �������� �뷡 �ð���
        curPlayTime = bgmSource.time;

        //�뷡 ��� ����
        isPlaying = bgmSource.isPlaying; 
    }


    /// <summary>
    /// �뷡�� ��� ����
    /// </summary>
    /// <returns>�뷡 ��� ���� ��ȯ</returns>
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
    /// ���� ���� �� N �� �� �뷡 ��� �ڷ�ƾ
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
    /// �뷡 �̸� ��� Clip ���� 
    /// </summary>
    /// <param name="clip"></param>
    public void SetAudioClip(AudioClip clip)
    {
        bgmSource.clip = clip;
    }

    /// <summary>
    /// �̸� ��� ���/���� ����
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
