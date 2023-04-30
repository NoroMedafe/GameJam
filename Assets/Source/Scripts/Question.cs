using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private string _keyQuestion;

    public string KeyQuestion => _keyQuestion;
    public void CreateQuestion(int idOutpost, string nameRecource)
    {
        _text.text = $"����� {nameRecource} �� �������� {idOutpost}";
        _keyQuestion = nameRecource + idOutpost.ToString();
    }
}
