﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class RoundData
{
    public string name;
    public int EnemyHP;
    public int PlayerHP;
    public int timeLimitInSeconds;
    public int pointsAddedForCorrectAnswer;
    public QuestionData[] questions;

}