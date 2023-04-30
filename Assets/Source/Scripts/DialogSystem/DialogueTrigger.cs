using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    [SerializeField] private DialogueManager _dialogueManager;

    private void Start()
    {
        _dialogueManager.StartDialogue(_dialogue);
    }

    public void TriggerDialogue()
    {
        _dialogueManager.StartDialogue(_dialogue);
    }
}
