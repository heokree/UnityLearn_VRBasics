using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Elevator : MonoBehaviour
{
    Transform original;
    public Transform player;

    Animator animator;
    public TMP_Text floorText;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Door", true);
            Invoke("Go", 1.0f);
        }
    }

    private void Go() {
        original = player.parent;
        player.SetParent(this.transform);
        animator.SetBool("Go", true);
        animator.SetBool("Door", false);
    }

    public void Arrived()
    {
        //player.SetParent(original);
        floorText.text = "2 F";
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Door", true);
        }
    }
}
