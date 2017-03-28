using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_SubPingSound : ON_SubPing {

    public GameObject pinger;
    AudioSource aud;
    GameObject thisPinger;

	public override void Ping () {
        Debug.Log("pinged");
        thisPinger = Instantiate(pinger);
        thisPinger.transform.parent = pingContainer.transform;
        aud = thisPinger.GetComponent<AudioSource>();
        thisPinger.GetComponent<ChooseRandomAudio>().Choose();
        aud.Play();
        //StartCoroutine(DestroyAudioOnCompletion());
    }

    IEnumerator DestroyAudioOnCompletion()
    {
        while (aud.isPlaying)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(thisPinger);
    }

}
