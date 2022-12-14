using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Building : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (SceneManager.GetActiveScene().name == "Level") {
            SceneManager.LoadScene("House");
        } else if (SceneManager.GetActiveScene().name == "House") {
            SceneManager.LoadScene("Level");
        }
        
        
        return true;
    }
}
