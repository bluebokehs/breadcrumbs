using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Building : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public GameObject player;
    public GameObject boxes;
    public GameObject winScreen;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (!inventory.HasKey3) {
            if (player.transform.position.z <= 600) {
                player.transform.position = new Vector3(490, 13, 637);
            } else {
                player.transform.position = new Vector3(490, 12, 487);
            }
        } else {
            boxes.SetActive(false);
            winScreen.SetActive(true);
            if (player.transform.position.z <= 600) {
                player.transform.position = new Vector3(470, 13, 637);
            } else {
                player.transform.position = new Vector3(490, 12, 487);
            }
        }
        
        
        
        return true;
    }
}
