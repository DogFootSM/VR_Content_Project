using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//박스 피격 방향
public enum BoxDir { Left, Right, Up, Down, SIZE }

//박스의 색깔
public enum BoxColor { Red, Blue, SIZE }

//현재 게임 상태
public enum GameState {Ready, Start, End, SIZE}