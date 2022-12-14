using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager2 : MonoBehaviour
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

        sentences.Enqueue(dialogue1.sentences[0]);

        sentences.Enqueue(dialogue.sentences[0]);

        sentences.Enqueue(dialogue1.sentences[1]);

        sentences.Enqueue(dialogue.sentences[1]);

        sentences.Enqueue(dialogue1.sentences[2]);

        sentences.Enqueue(dialogue.sentences[2]);

        sentences.Enqueue(dialogue1.sentences[3]);
        
        DisplayNextSentence(dialogue, dialogue1, dialogue2);
    }

    public void DisplayNextSentence(Dialogue dialogue, Dialogue dialogue1, Dialogue dialogue2) {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        
        if (sentences.Count == 7) {
            nameText.text = dialogue1.name;
        } else if (sentences.Count == 6) {
            nameText.text = dialogue.name;
        } else if (sentences.Count == 5) {
            nameText.text = dialogue1.name;
        } else if (sentences.Count == 4) {
            nameText.text = dialogue.name;
        } else if (sentences.Count == 3) {
            nameText.text = dialogue1.name;
        } else if (sentences.Count == 2) {
            nameText.text = dialogue.name;
        } else if (sentences.Count == 1) {
            nameText.text = dialogue1.name;
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
