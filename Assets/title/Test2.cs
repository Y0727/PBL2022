using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    // InputFieldのText参照用
    public TMP_InputField Field;

    // Start と Update は省略

    // InputFieldの文字が変更されたらコールバックされる
    public void OnValueChanged()
    {
        string input = Field.GetComponent<TMP_InputField>().text;
        GetComponent<TMP_Text>().text = input;
    }
}
