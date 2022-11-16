using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Key1 _key;

    public string InteractionPrompt => _prompt;
    

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        inventory.HasCode = true;
        Debug.Log("Reading Book!");
        return true;
    }
}
