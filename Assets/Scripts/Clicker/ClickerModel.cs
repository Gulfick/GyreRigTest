using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerModel : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonController;
    [SerializeField] private TextView _textView;

    private long _clickCount;

    private void Awake()
    {
        _buttonController.AddListener(OnClick);
    }

    private void OnClick()
    {
        _clickCount++;
        _textView.UpdateText(_clickCount.ToString());
    }
}
