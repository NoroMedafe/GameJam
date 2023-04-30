using UnityEngine;

public class Boots : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private Dialogue _dialogue;

    private bool _isDialogueStarted = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player) && _isDialogueStarted == false)
        {
            _dialogueManager.StartDialogue(_dialogue);
            _isDialogueStarted = true;
        }
    }
}
