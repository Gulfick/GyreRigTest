using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CubeSpawnerView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _spawnIntervalField;
    [SerializeField] private TMP_InputField _speedField;
    [SerializeField] private TMP_InputField _distanceField;

    public void Initialize(UnityAction<string> spawnAction, UnityAction<string> speedAction,
        UnityAction<string> distanceAction, float[] valueArray)
    {
        _spawnIntervalField.text = valueArray[0].ToString(CultureInfo.CurrentCulture);
        _speedField.text = valueArray[1].ToString(CultureInfo.CurrentCulture);
        _distanceField.text = valueArray[2].ToString(CultureInfo.CurrentCulture);

        _spawnIntervalField.onValueChanged.AddListener(spawnAction);
        _speedField.onValueChanged.AddListener(speedAction);
        _distanceField.onValueChanged.AddListener(distanceAction);
    }
}