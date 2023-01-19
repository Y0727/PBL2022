using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//追加する！
using UnityEngine.UI;
 
public class UserNameRegistration : MonoBehaviour {
 
  //オブジェクトと結びつける
  public InputField inputField;
  public Text text;
 
  void Start () {
    //Componentを扱えるようにする
             inputField = inputField.GetComponent<InputField> ();
      text = text.GetComponent<Text> ();
 
    }
 
    public void InputText(){
                //テキストにinputFieldの内容を反映
         text.text = inputField.text;
 
     }
 
}
