using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton_practice : MonoBehaviour
{

    public Text answerText;

    private AnswerData answerData;
    private PracticeController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<PracticeController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }


    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}