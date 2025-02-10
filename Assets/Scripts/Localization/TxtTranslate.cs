using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TxtTranslate : MonoBehaviour
{
    public string ID;
    TextMeshProUGUI _txt;

    private void Start()
    {
        _txt = GetComponent<TextMeshProUGUI>();

        Translate();
    }

    public void Translate()
    {
        _txt.text = LocalizationManager.instance.Translate(ID);
    }
}
