using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    //[HideInInspector]
    public int RoundNum = 0;
    //[HideInInspector]
    public int LevelR;
    public int finalScore;
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        RoundNum = PlayerPrefs.GetInt("roundnum", 0);
        LevelR = PlayerPrefs.GetInt("levelR", 0);
        finalScore = PlayerPrefs.GetInt("finalScore", 0);
        SceneManager.LoadScene("Menu");
        
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[RoundNum];
    }

    

    // Update is called once per frame
    void Update()
    {

    }
}
