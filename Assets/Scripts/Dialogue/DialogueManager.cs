using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

	//public static DialogueManager instance = null;
	public Text titleText;
	public Text dialogueText; 
	private Queue<string> sentences;
	public Animator animator;

	void Start(){
		sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue){
		animator.SetBool ("IsOpen", true);
		sentences = new Queue<string> ();
		titleText.text = dialogue.name;	
		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}
		DisplayNextSentences ();
	}  

	public void DisplayNextSentences(){
		if (sentences.Count == 0){
			EndDialogue ();
			return;
		}
		string sentence = sentences.Dequeue ();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence){
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text = dialogueText.text+letter;
			yield return null;
		}
	}

	void EndDialogue(){
		animator.SetBool ("IsOpen", false);
	}

}
