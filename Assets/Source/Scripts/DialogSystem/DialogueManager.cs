using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private Animator _animator;

    private Queue<string> _sentences = new Queue<string>();
    private Coroutine _coroutine;

    private void Start()
    {
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _animator.SetBool("IsOpen", true);

        _nameText.text = dialogue.Name;

        _sentences.Clear();

        foreach (string sentence in dialogue.Sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(TypeSyntance(sentence));
    }

    private void EndDialogue()
    {
        _animator.SetBool("IsOpen", false);
    }

    private IEnumerator TypeSyntance(string sentence)
    {
        _dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return null;
        }
    }
}