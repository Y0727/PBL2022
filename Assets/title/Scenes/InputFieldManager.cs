using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    protected static string Name = "";
    //出力用のテキスト
    public Text displayText;

    //inputFieldのOnEndEditに設定する用の関数
    public void OnEndEdit()
    {
        //InputFieldコンポーネントのtextを変数に代入
        string inputFieldText = GetComponent<InputField>().text;

        //出力用のテキストに代入
        displayText.text = inputFieldText;
        Name = inputFieldText;

    }

    public static string GetName()
    {
        return Name;
    }
}
