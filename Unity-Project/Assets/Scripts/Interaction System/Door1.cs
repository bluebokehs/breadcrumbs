using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] public AudioClip _doorSound;
    AudioSource source;

    public string InteractionPrompt => _prompt;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasKey1) {
            Quaternion target = Quaternion.Euler(0, 210, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 12.0f);
            source.PlayOneShot(_doorSound, 0.8F);
            inventory.HasKey1 = false;
            Debug.Log("Opening Door!");
            return true;
        }

        Debug.Log("No Key Found!");
        return false;
    }
}
