using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;
    private bool hasInteracted = false;
    public GameObject visual;
    public GameObject boxes;
    public GameObject player;
    public GameObject trigger;
    public GameObject toolTip;
    public Animator animator;
    [SerializeField] public AudioClip _voiceSound;
    AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && Vector3.Distance(player.transform.position, trigger.transform.position) <= 5) {
            if (!hasInteracted) {
                visual.SetActive(true);
                boxes.SetActive(false);
                source.PlayOneShot(_voiceSound, 1F);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                hasInteracted = true;
            } else {    
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
                if (!animator.GetBool("IsOpen")) {
                    visual.SetActive(false);
                    boxes.SetActive(true);
                    toolTip.SetActive(false);
                }
            }
        }
    }
}
