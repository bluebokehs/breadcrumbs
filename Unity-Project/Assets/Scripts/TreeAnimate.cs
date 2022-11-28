using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimate : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt; 
    [SerializeField] private Animator treeAnimator;
    [SerializeField] private GameObject peach;

    public bool Interact(Interactor interactor)
    {
        treeAnimator.SetBool("isGrowing", true);
        peach.transform.position = new Vector3(527, 1, 231);
        Debug.Log("The tree has grown!");
        return true;
    }
}
