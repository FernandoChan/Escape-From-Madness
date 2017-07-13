﻿using UnityEngine;

public class StopScreamCollider : MonoBehaviour {

    public GameObject blockingStretcher, flashlightObject;

    Flashlight flashlight;
    DaughterScream screamPlayer;
    Chainsaw chainsaw;
    bool hasCollided;

	void Start () {
        flashlight = FindObjectOfType<Flashlight>();
        screamPlayer = FindObjectOfType<DaughterScream>();
        chainsaw = FindObjectOfType<Chainsaw>();

        hasCollided = false;
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && screamPlayer.GetComponent<AudioSource>().isPlaying) {
            screamPlayer.StopScreams();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Play();

            if (!hasCollided) {
                hasCollided = true;
                flashlightObject.SetActive(false);
            }
            
            if (flashlight.HasPickedUp()) {
                Destroy(blockingStretcher);
                chainsaw.PlayChainsawAudioAfter(5f);
            }        
        }
    }

    public bool HasCollided()
    {
        return hasCollided;
    }
}