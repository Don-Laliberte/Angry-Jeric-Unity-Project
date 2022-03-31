using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{

    GameScoreHandler gameScoreHandler;
    [SerializeField] int scoreValue = 150;
    [SerializeField] private int healthPoints;
    [SerializeField] Sprite death;
    [SerializeField] private float despawnDelay;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private bool deathFlag = false;

    [Header("Sound Effects")]
    [SerializeField] AudioClip[] effects;
    [SerializeField] float[] volume;
    [SerializeField] int SoundTriggerPercentage;
    SoundHandler soundHandler;
 

    void Awake() {
        if (effects.Length != 0)
            soundHandler = new SoundHandler(effects, volume);


        spriteRenderer = GetComponent<SpriteRenderer>();
        gameScoreHandler = FindObjectOfType<GameScoreHandler>();
    }

    private void Start() {
        deathFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0 && deathFlag == false) {
            deathFlag = true;
            spriteRenderer.sprite = death;
            gameScoreHandler.ModifyPoints(scoreValue);
            Invoke(nameof(DespawnEnemy), despawnDelay);
            EnemyHandler.setWinBool(true);
        }
    }

    void DespawnEnemy() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other != null) {
                 //Debug.Log(other.relativeVelocity.magnitude * other.rigidbody.mass);
            if (other.relativeVelocity.magnitude * other.rigidbody.mass >= 8) {
                //Debug.Log("other.relativeVelocity.magnitude * other.rigidbody.mass");
                //Debug.Log("Heavy Hit");
                healthPoints -= 7;
                int rng = Random.Range(1,101);
            
                if (rng >= 0 && rng <= SoundTriggerPercentage) {
                    soundHandler.playRandomSound();
                }
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
        }


 
    }
}
