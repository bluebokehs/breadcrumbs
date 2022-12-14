using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public Dialogue dialogue;

    public string InteractionPrompt => _prompt;
    private bool hasInteracted = false;

    public bool Interact(Interactor interactor)
    {
        if (!hasInteracted) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            hasInteracted = true;
        } else {    
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
        
        return true;
    }
}
