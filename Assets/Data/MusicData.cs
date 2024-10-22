using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName ="CreateMusic/Music")]

public class MusicData : ScriptableObject
{
    [Header("Album Data")]
    [Tooltip("Cover Image")]
    public Sprite coverImage;

    [Tooltip("Music Title")]
    public string musicTitle;

    [Tooltip("Music Clip")]
    public AudioClip audioClip;

    [Tooltip("High Score")]
    public int highScore;
}
