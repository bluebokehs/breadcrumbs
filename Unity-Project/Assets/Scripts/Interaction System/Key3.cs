using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key3 : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject image;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        inventory.HasKey3 = true;
        key.SetActive(false);
        image.SetActive(true);
        Debug.Log("Key was picked up!");
        return true;
    }
}
