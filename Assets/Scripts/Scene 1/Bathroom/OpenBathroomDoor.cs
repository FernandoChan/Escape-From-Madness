﻿using UnityEngine;
using UnityEngine.UI;

public class OpenBathroomDoor : MonoBehaviour {

    public Text playerMessage;

    BathroomDoor door;
    bool isColliding;

    void Start() {
        door = FindObjectOfType<BathroomDoor>();
        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !door.IsDoorOpen() && !door.IsActive()) {
            isColliding = true;
            playerMessage.text = "F - Open Door";
        } else if (door.IsDoorOpen() || door.IsActive()) {
            playerMessage.text = "";
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            isColliding = false;
            playerMessage.text = "";
        }
    }

    public bool IsCollidingWithPlayer() {
        return isColliding;
    }
}