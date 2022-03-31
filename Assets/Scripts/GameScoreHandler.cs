using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameScoreHandler : MonoBehaviour
{

    private int gameScore;
    static GameScoreHandler instance;

    void ManageSingleton () {
        if (instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Awake() {
        ManageSingleton();
    }

    public void Start() {
        gameScore = 0;
    }


    public void ModifyPoints(int amount) {
        gameScore += amount;
    }

    public int getScore() {
        return gameScore;
    }

    public void ResetPoints() {
        gameScore = 0;
    }
}
