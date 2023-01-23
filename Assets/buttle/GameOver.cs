using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    

    private TextMeshProUGUI OverText; 
    private Text text1;
    private Text text2;

    private GameObject button_retry;
    private GameObject button_toStart;
    private GameObject button_retry_text;
    private GameObject button_toStart_text;
    private GameObject button_rotate;
    private Image panel;

    private Button RetryButton;
    private Button RetryButton02;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("yes");
        RetryButton= GameObject.Find ("Canvas/GameOverUI/RetryButton").GetComponent<Button>();
        RetryButton02= GameObject.Find ("Canvas/GameOverUI/RetryButton02").GetComponent<Button>();

        RetryButton.enabled=false;
        RetryButton02.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerExit2D(Collider2D other){
        Debug.Log("yes");
        
    
        Destroy(other.gameObject);

        GameObject obj = GameObject.Find ("GameManager");
        button_retry = GameObject.Find ("RetryButton");
        button_toStart = GameObject.Find ("RetryButton02");
        button_retry_text= GameObject.Find ("RetryButtonText");
        button_toStart_text = GameObject.Find ("RetryButton02Text");
        button_rotate = GameObject.Find("rotateButton");


        OverText = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        text1=GameObject.Find("RetryButtonText").GetComponent<Text>();
        text2=GameObject.Find("RetryButton02Text").GetComponent<Text>();
        panel=GameObject.Find("Panel").GetComponent<Image>();

        RetryButton.enabled=true;
        RetryButton02.enabled=true;
        // 指定したオブジェクトを削除
        Destroy (obj.GetComponent<AnimalGenerator>());
    /* ゲームオーバー処理 */
       

        button_toStart.GetComponent<Image> ().color = new Color(255,255,255,255);
        button_retry.GetComponent<Image> ().color = new Color(255,255,255,255);
        OverText.color=new Color (255, 255, 255, 255);
        text1.color=new Color (0, 0, 0, 255);
        text2.color=new Color (0, 0, 0, 255);
        panel.color = new Color32 (0, 0, 0, 60);
        button_rotate.GetComponent<Image>().color = new Color(255,255,255,0);



        /*ColorBlock cb = button_toStart.GetComponent<Button> ().colors;
        cb.normalColor = new Color(255,255,255,255);
        button_toStart.GetComponent<Button> ().colors = cb;


        ColorBlock cb2 = button_retry.GetComponent<Button> ().colors;
        cb2.normalColor = new Color(255,255,255,255);
        button_retry.GetComponent<Button> ().colors = cb2;
        */


        Debug.Log("yes");
    }
}
