using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(string text)
    {
        _text.text = text;
    }
}
