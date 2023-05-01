using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Question : MonoBehaviour
{
    public int Index { get; set; }
    [SerializeField] private TMP_Text _text;

    private string _keyQuestion;

    public string KeyQuestion => _keyQuestion;
    public void CreateQuestion(int idOutpost, string nameRecource)
    {
        _text.text = $"Ïğèíåñè {nameRecource} íà àâàíïîñò {OutpostIdToName(idOutpost)}";
        _keyQuestion = nameRecource + idOutpost.ToString();
        Debug.Log($"Key request {_keyQuestion}");
    }

    private string OutpostIdToName(int id)
    {
        string result = id switch
        {
            0 => "CÂ",
            1 => "ŞÂ",
            2 => "ŞÇ",
            3 => "ÑÇ",
            _ => ""
        };
        return result;
    }
}
