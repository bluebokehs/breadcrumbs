using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memButton : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public bool clicked = false;
    public string InteractionPrompt => _prompt; 

    public bool Interact(Interactor interactor)
    {
        if (clicked) return false;
        else
        {
            clicked = true;
            Debug.Log("clicked");
            return true;
        }
    }
}
