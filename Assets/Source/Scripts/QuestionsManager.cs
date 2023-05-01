using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    [SerializeField] private Question _question;
    private MissionArrowsManager _missionArrows;


    private List<Question> _questionList = new();
    private int _currentIndex = 0;

    private void Start()
    {
        _missionArrows = FindObjectOfType<MissionArrowsManager>();
    }

    public void CreateQuestion(int idOutpost, string nameRecource, Sprite icon, Vector2 outpostPosition)
    {
        Question question = Instantiate(_question, gameObject.transform);
        question.transform.localScale = new Vector3(1, 1, 1);
        question.CreateQuestion(idOutpost, nameRecource);
        question.Index = _currentIndex;
        _questionList.Add(question);

        _missionArrows.AddMission(outpostPosition, icon, _currentIndex);

        _currentIndex++;
    }

    public void ComptiteQuestion(int idOutpost, string nameRecource)
    {
        string key = nameRecource + idOutpost.ToString();

        Debug.Log($"Removing {key}");

        foreach (var item in _questionList)
        {
            if (item.KeyQuestion == key)
            {
                Destroy(item.gameObject);
                _questionList.Remove(item);
                _missionArrows.RemoveMission(item.Index);
                break;
            }
        }
    }
}
