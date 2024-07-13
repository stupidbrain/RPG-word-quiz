using UnityEngine;
using System.Collections;

public class urlBtn : MonoBehaviour
{
    public string url = "http://fischhaus.com/";

    public void OpenURL()
    {
        Application.OpenURL(url);
        //Debug.Log("is this working?");
    }

}