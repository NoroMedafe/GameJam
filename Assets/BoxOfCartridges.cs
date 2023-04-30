using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOfCartridges : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private Dialogue _dialogue;
    [SerializeField] private CanvasGroup _canvasGroup;

    private bool _isDialogueStarted = false;

    private float _elapsedTime = 0;
    private float _hintTime = 5;
    private bool _isFoundBullets = false;

    private void Start()
    {
        _canvasGroup.alpha = 0;
    }

    private void Update()
    {
        if (_isFoundBullets)
            _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _hintTime)
            _canvasGroup.alpha = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player) && _isDialogueStarted == false)
        {
            _canvasGroup.alpha = 1;
            _isFoundBullets = true;
            _dialogueManager.StartDialogue(_dialogue);
            _isDialogueStarted = true;
        }
    }
}
