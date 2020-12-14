using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurrentText : MonoBehaviour
{
    private Text _textNumberclicked;
    [SerializeField] private Figure _figura;

    private void Start() {
        _textNumberclicked = GetComponentInChildren<Text>();
        _figura.ClickObjectEvent += Сonferment;
    }

    private void Сonferment(int currentText) {
        _textNumberclicked.text = currentText.ToString();
    }
}
