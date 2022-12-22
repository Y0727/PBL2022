using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OnClickDeckStartButton()
    {
        SceneManager.LoadScene("VS_Ryu");
    }

    public void OnClickButtleHomeButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

