using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    GameScoreHandler gameScoreHandler;
    [SerializeField] int scoreValue = 50;
    [Header("Sound Effects")]
    [SerializeField] AudioClip[] effects;
    [SerializeField] float[] volume;

    SoundHandler soundHandler;

    private void Awake() {
        if (effects.Length != 0)
            soundHandler = new SoundHandler(effects, volume);

        gameScoreHandler = FindObjectOfType<GameScoreHandler>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Coin Collected");
        if (other.gameObject.tag == "Player") {
            gameScoreHandler.ModifyPoints(scoreValue);
            soundHandler.playRandomSound();
            Destroy(gameObject);
        }
    }
}
