using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager1 : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, Dialogue dialogue1, Dialogue dialogue2) {

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        sentences.Enqueue(dialogue.sentences[0]);

        foreach(string sentence in dialogue1.sentences) {
            sentences.Enqueue(sentence);
        }

        foreach(string sentence in dialogue2.sentences) {
            sentences.Enqueue(sentence);
        }

        sentences.Enqueue(dialogue.sentences[1]);

        

        DisplayNextSentence(dialogue, dialogue1, dialogue2);
    }

    public void DisplayNextSentence(Dialogue dialogue, Dialogue dialogue1, Dialogue dialogue2) {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        
        if (sentences.Count == 4) {
            nameText.text = dialogue.name;
        } else if (sentences.Count == 3) {
            nameText.text = dialogue1.name;
        } else if (sentences.Count == 2) {
            nameText.text = dialogue2.name;
        } else if (sentences.Count == 1) {
            nameText.text = dialogue.name;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        animator.SetBool("IsOpen", false);
        
    }

    
}
