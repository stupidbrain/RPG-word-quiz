using UnityEditor;
using UnityEngine;
using System.IO;

public class CSVtoSO
{
    private static string QuizPath = "/Editor/CSVs/Greek01.csv";

    [MenuItem("Tools/Create Quiz Object")]

    public static void CreateQuiz()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + QuizPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            if (splitData.Length != 5)
            {
                Debug.Log(s + "does not have 5 values");
                return;
            }

            Quiz quiz = ScriptableObject.CreateInstance<Quiz>();
            
            quiz.questionText = splitData[0];
            quiz.wordFreq = int.Parse(splitData[1]);
            quiz.ans00 = splitData[2];
            quiz.ans01 = splitData[3];
            quiz.ans02 = splitData[4];

            AssetDatabase.CreateAsset(quiz, $"Assets/Quiz/{quiz.questionText}.asset");
        }

        AssetDatabase.SaveAssets();
    }



}

