using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PracticeController : MonoBehaviour
{
    public Text questionDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    
    //private PlayerController playercontroller;
    private bool isHighlighted;
    private bool isRoundActive;
    private int questionIndex;
    private int RoundIndex = 0;
        
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        //playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        dataController = FindObjectOfType<DataController>();
        questionIndex = 0;
        currentRoundData = dataController.allRoundData[RoundIndex];
        questionPool = currentRoundData.questions;
        
        isRoundActive = true;
        ShowQuestion_highlighted();
        
    }

    private void ShowQuestion_highlighted()
    {
        RemoveAnswerButtons();
        
        if (questionPool[questionIndex].Highlighted)
        {
            QuestionData questionData = questionPool[questionIndex];
            questionDisplayText.text = questionData.questionText;
            for (int i = 0; i < questionData.answers.Length; i++)
            {
                GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
                answerButtonGameObjects.Add(answerButtonGameObject);
                answerButtonGameObject.transform.SetParent(answerButtonParent);
                AnswerButton_practice answerButton = answerButtonGameObject.GetComponent<AnswerButton_practice>();
                answerButton.Setup(questionData.answers[i]);
            }
        }
        else
        {
            AnswerButtonClicked(true);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            currentRoundData.questions[questionIndex].Highlighted = false;
            
        }
        else
        {
            currentRoundData.questions[questionIndex].Highlighted = true;
        }

        if (isRoundActive && questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion_highlighted();
        }
        else if (dataController.allRoundData.Length > RoundIndex + 1)
        {
            Debug.Log("next round");
            RoundIndex++;
            currentRoundData = dataController.allRoundData[RoundIndex];
            questionPool = currentRoundData.questions;
            questionIndex = 0;
            ShowQuestion_highlighted();
        }
        else if (isRoundActive)
        {
            EndRound();
        }
    }
         
    public void EndRound()
    {
        
        isRoundActive = false;
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetSceneBtn()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}