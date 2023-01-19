using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class TitleScene: MonoBehaviour {
 
    // Use this for initialization
    void Start () {
        Invoke("ChangeScene", 1.5f);
    }
    
    // Update is called once per frame
    void Update () {
        
    }
 
    void ChangeScene()
    {
        SceneManager.LoadScene("DeckRegisterScene");
    }

    void OnclickToHomeButton()
    {
        SceneManager.LoadScene("VS_Ryu");
    }
}