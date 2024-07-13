using UnityEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quiz", menuName = "Assets/New Quiz")]
public class Quiz: ScriptableObject
{
    public string questionText;
    public int wordFreq;
    public string ans00;
    public string ans01;
    public string ans02;
    public bool Highlighted;
}