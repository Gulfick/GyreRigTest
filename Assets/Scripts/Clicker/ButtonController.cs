using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button _button;

    public void AddListener(UnityAction call)
    {
        _button.onClick.AddListener(call);
    }
}
