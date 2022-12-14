using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger3 : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue1;
    public Dialogue dialogue2;
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
        FindObjectOfType<DialogueManager1>().StartDialogue(dialogue, dialogue1, dialogue2);
    }

    public void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && Vector3.Distance(player.transform.position, trigger.transform.position) <= 5) {
            if (!hasInteracted) {
                visual.SetActive(true);
                boxes.SetActive(false);
                source.PlayOneShot(_voiceSound, 1F);
                FindObjectOfType<DialogueManager1>().StartDialogue(dialogue, dialogue1, dialogue2);
                hasInteracted = true;
            } else {    
                FindObjectOfType<DialogueManager1>().DisplayNextSentence(dialogue, dialogue1, dialogue2);
                if (!animator.GetBool("IsOpen")) {
                    visual.SetActive(false);
                    boxes.SetActive(true);
                    toolTip.SetActive(false);
                }
            }
        }
    }
}
