using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHome : MonoBehaviour
{
    
    private GameObject button_ob;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickToHomeButton()
    {
        Debug.Log("Doing");
        //SceneManager.LoadScene("Home");
    }

}
