using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{

    [Header("Sound Effects")] 
    [SerializeField] AudioClip[] hitEffects;
    [SerializeField] float[] volumes;
    // Start is called before the first frame update

    public SoundHandler (AudioClip[] effects, float[] volumes) {
        this.hitEffects = effects;
        this.volumes = volumes;
    }

    public void playRandomSound() {
        if (hitEffects.Length != 0) {
            int soundRng = Random.Range(0, hitEffects.Length);
            AudioSource.PlayClipAtPoint(hitEffects[soundRng], Camera.main.transform.position, volumes[soundRng]);
        }
    }

}
