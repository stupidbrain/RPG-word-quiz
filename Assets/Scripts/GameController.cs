using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text resultText;
    public GameObject NextBtn;
    public GameObject RetryBtn;
    public int enemyDamage = 10;
    public int playerDamage = 10;
    
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    
    private PlayerController playercontroller;
    private EnemyController enemycontroller;
    private Animator PlayerIconAnim;
    //private int IconAnim;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private bool nextLevel=false;
    
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        PlayerIconAnim = GameObject.FindGameObjectWithTag("PlayerIcon").GetComponent<Animator>();
        enemycontroller = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        dataController = FindObjectOfType<DataController>();
        RetryBtn.SetActive(false);
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();
        playerScore = dataController.finalScore;
        scoreDisplayText.text = "Score: " + playerScore.ToString();
        questionIndex = 0;
        ShowQuestion();
        isRoundActive = true;
        Debug.Log("Round Num: " + dataController.RoundNum);
        switch (dataController.RoundNum)
        {
            case 4:
                nextLevel = true;
                break;
            case 10:
                nextLevel = true;
                break;
            default:
                nextLevel = false;
                break;
        }
        PlayerIconAnim.SetInteger("Level", dataController.RoundNum);
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;
        
        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
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
            //Debug.Log(currentRoundData.questions[questionIndex].questionText);
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            currentRoundData.questions[questionIndex].Highlighted = false;
            dataController.finalScore = playerScore;
            playercontroller.Attack();
            enemycontroller.Hurt(enemyDamage);
            //Debug.Log(enemycontroller.life);
            if (enemycontroller.life <= 0)
            {
                resultText.text = "You Win";
                NextRound();
            }
        }
        else
        {
            enemycontroller.Attack();
            playercontroller.Hurt(playerDamage);
            currentRoundData.questions[questionIndex].Highlighted = true;
            if (playercontroller.life <= 0)
            {
                resultText.text = "You Loss";
                EndRound();
            }
        }
        //Debug.Log("Question Length" + questionPool.Length + "Question Index+1: " + (questionIndex + 1));

        if (isRoundActive && questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else if (isRoundActive)
        {
            
            Debug.Log("End Round");
            EndRound();
        }
    }

    public void NextRound()
    {
        dataController.RoundNum ++;
        
        isRoundActive = false;
        questionDisplay.SetActive(false);
        resultText.text = "You Win";
        NextBtn.SetActive(true);
        RetryBtn.SetActive(false);
        roundEndDisplay.SetActive(true);
        
    }
 
    public void EndRound()
    {
        
        isRoundActive = false;
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
        NextBtn.SetActive(false);
        RetryBtn.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetSceneBtn()
    {
        if (!nextLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            dataController.LevelR++;
            SceneManager.LoadScene("Menu");
        }   
        
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }

        }
    }
}