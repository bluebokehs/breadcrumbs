using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour, IInteractable
{
    [SerializeField] public string _prompt;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject vendingMachine;
    [SerializeField] public AudioClip _vendingSound;
    AudioSource source;

    public string InteractionPrompt => _prompt;

    void Start() {
        source = vendingMachine.GetComponent<AudioSource>();
    }

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasCode) {
            inventory.HasKey = true;
            source.PlayOneShot(_vendingSound, 0.8F);
            key.SetActive(false);
            Debug.Log("Key was picked up!");
            return true;
        }

        Debug.Log("No Key Found!");
        return false;
    }
}
