using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    [SerializeField] private Question _question;

    private List<Question> _questionList = new();
     
    public void CreateQuestion(int idOutpost, string nameRecource)
    {
        Question question = Instantiate(_question);
        question.transform.parent = gameObject.transform;
        question.transform.localScale = new Vector3(1, 1, 1);
        question.CreateQuestion(idOutpost, nameRecource);
        _questionList.Add(question);
    }

    public void ComptiteQuestion(int idOutpost, string nameRecource)
    {
        string key = nameRecource + idOutpost.ToString();

        foreach (var item in _questionList)
        {
            if (item.KeyQuestion == key)
            {
                Destroy(item.gameObject);
                _questionList.Remove(item);
                break;
            }
        }
    }
}
