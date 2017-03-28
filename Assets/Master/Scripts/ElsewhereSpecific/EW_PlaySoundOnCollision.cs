using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EW_PlaySoundOnCollision : MonoBehaviour {
    public AudioSource aud;
    public float resetTime = 1;
    bool triggerable = true;

    private void OnCollisionEnter(Collision collision) {

        if (triggerable) {
          
            aud.Play();
            aud.transform.position = collision.collider.transform.position;
            triggerable = false;
            StartCoroutine(reset());
        }
    }

    IEnumerator reset() {

        float counter = 0;
        while (counter < resetTime) {
            counter += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        triggerable = true;
    }
   
}
