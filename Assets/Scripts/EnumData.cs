using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//�ڽ� �ǰ� ����
public enum BoxDir { Left, Right, Up, Down, SIZE }

//�ڽ��� ����
public enum BoxColor { Red, Blue, SIZE }

//���� ���� ����
public enum GameState {Ready, Start, End, SIZE}