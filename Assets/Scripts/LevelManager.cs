using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameScoreHandler gameScoreHandler;

    private void Start() {
        gameScoreHandler = FindObjectOfType<GameScoreHandler>();
    }
    public void LoadMainMenu() {
        Debug.Log("button pressed");
        SceneManager.LoadScene("Angry Jeric Main Menu");
        
    }
    public void LoadLevel() { 
        Debug.Log("button pressed");
        SceneManager.LoadScene("Angry Jeric Level 1");
        gameScoreHandler.ResetPoints();
        EnemyHandler.setWinBool(false);
    }
}
