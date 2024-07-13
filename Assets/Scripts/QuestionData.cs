using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuestionData
{
    public string questionText;
    public int wordFreq;
    public bool Highlighted;
    public AnswerData[] answers;
    
}