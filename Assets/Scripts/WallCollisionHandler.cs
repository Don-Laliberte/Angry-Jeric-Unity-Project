using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class WallCollisionHandler : MonoBehaviour
{
GameScoreHandler gameScoreHandler;

    

    [SerializeField] int scoreValue = 150;
    [SerializeField] private int healthPoints = 75;
    [SerializeField] SoundHandler soundHandler;

    private int maxHealth;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameScoreHandler = FindObjectOfType<GameScoreHandler>();
    }

    void Start() {
        maxHealth = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0) {
            gameScoreHandler.ModifyPoints(scoreValue);
            DespawnWall();
        }
        else if (healthPoints <= maxHealth * 0.50) {
            Color newColor = new Color(255,0,0,1);
            spriteRenderer.color = newColor;
        }

    }

    void DespawnWall() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other != null) {
                    GetComponentInChildren<ParticleSystem>().Play();
            if (other.relativeVelocity.magnitude * other.rigidbody.mass >= 8) {
                //Debug.Log("other.relativeVelocity.magnitude * other.rigidbody.mass");
                //Debug.Log("Heavy Hit");
                healthPoints -= 15;
            }
            else if (other.relativeVelocity.magnitude * other.rigidbody.mass >= 6) {
                //Debug.Log("other.relativeVelocity.magnitude * other.rigidbody.mass");
                //Debug.Log("Medium Hit");
                healthPoints -= 5;
            }
            else if (other.relativeVelocity.magnitude * other.rigidbody.mass >= 4) {
                //Debug.Log("other.relativeVelocity.magnitude * other.rigidbody.mass");
                //Debug.Log("Light Hit");
                healthPoints -= 1;
            }
            soundHandler.playRandomSound();
        }

    }

}
