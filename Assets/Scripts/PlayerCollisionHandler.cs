using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] AudioClip[] effects;
    [SerializeField] float[] volume;
    [SerializeField] int SoundTriggerPercentage;

    SoundHandler soundHandler;


    void Awake() {
        if (effects.Length != 0)
            soundHandler = new SoundHandler(effects, volume);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other != null) {
            if (other.relativeVelocity.magnitude * other.rigidbody.mass >= 8) {
            //Debug.Log("other.relativeVelocity.magnitude * other.rigidbody.mass");
            //Debug.Log("Heavy Hit");
            int rng = Random.Range(1,101);

                if (rng >= 0 && rng <= SoundTriggerPercentage) {
                soundHandler.playRandomSound();
                }
            }
            else if (other.relativeVelocity.magnitude * other.rigidbody.mass >= 6) {
            //Debug.Log("other.relativeVelocity.magnitude * other.rigidbody.mass");
            //Debug.Log("Medium Hit");
            int rng = Random.Range(1,101);

                if (rng >= 0 && rng <= SoundTriggerPercentage) {
                    soundHandler.playRandomSound();
                }
            }
            else if (other.relativeVelocity.magnitude * other.rigidbody.mass >= 4) {
                //Debug.Log("other.relativeVelocity.magnitude * other.rigidbody.mass");
                //Debug.Log("Light Hit");
            }
        }

    }
}
