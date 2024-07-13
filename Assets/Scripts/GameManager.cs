using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

	public AudioClip sceneMusic;
    
    DataController datacontroller;
    

    void Start () {
		MusicPlayer.ChangeMusic (sceneMusic);
        datacontroller = GameObject.FindGameObjectWithTag("dataController").GetComponent<DataController>();
        
    }

    public void Saveing()
    {
        PlayerPrefs.SetInt("roundnum", datacontroller.RoundNum);
        PlayerPrefs.SetInt("levelR", datacontroller.LevelR);
        PlayerPrefs.SetInt("finalScore", datacontroller.finalScore);
    }

    public void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }

}


