using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIUpdater : MonoBehaviour
{

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] Canvas winScreen;
    GameScoreHandler gameScoreHandler;


    void Awake() {
        gameScoreHandler = FindObjectOfType<GameScoreHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + gameScoreHandler.getScore());
        finalScoreText.SetText("Score: " + gameScoreHandler.getScore());
    }

    public void toggleWinScreen(bool toggle) {
        winScreen.gameObject.SetActive(toggle);
    }
}
