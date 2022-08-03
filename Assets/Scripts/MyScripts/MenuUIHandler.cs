using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerName;
    public void StartGame()
    {
        Debug.Log("Player Name is: " + playerName.text); ;
        SceneManager.LoadScene(1);
        
    }

    public void ExitGame()
    {
        
#if UNITY_EDITOR 
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

        PlayerName.Instance.SavePlayerNameAndScore();    
        
    }
}
