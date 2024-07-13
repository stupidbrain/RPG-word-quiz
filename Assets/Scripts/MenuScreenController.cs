using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    DataController datacontroller;
    public GameObject[] Flag;

    int levelreached = 0;

    private void Start()
    {
        datacontroller = FindObjectOfType<DataController>();
        
        levelreached = datacontroller.LevelR;
        if (Flag[0] != null)
        {
            for (int i = 0; i < 5; i++)
            {
                Flag[i].SetActive(false);
            }
            switch (levelreached)
            {
                case 0:
                    Flag[0].SetActive(true);
                    break;
                case 1:
                    Flag[1].SetActive(true);
                    break;
                case 2:
                    Flag[2].SetActive(true);
                    break;
                case 3:
                    Flag[3].SetActive(true);
                    break;
                case 4:
                    Flag[4].SetActive(true);
                    break;
                default:
                    Debug.Log("No level set");
                    break;
            }
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game"+datacontroller.LevelR);
    }

    public void Level02()
    {
        SceneManager.LoadScene("Game1");
        datacontroller.RoundNum = 5;
    }


    public void Practice()
    {
        SceneManager.LoadScene("Practice");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level0"+datacontroller.LevelR);
    }
}