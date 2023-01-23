using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AnimalGenerator : MonoBehaviour{

    public GameObject[] animals=new GameObject[6];//どうぶつ取得配列
    public Camera mainCamera;//カメラ取得用変数
    public float pivotHeight = 3;//生成位置の基準
    public float underLim = 0.8f;

    public static int animalNum = 0;//生成された動物の個数を保管
    public static bool isGameOver = false;//ゲームオーバー判定

    private GameObject geneAnimal;//どうぶつ生成（単品）
    public bool isGene;//生成されているか
    public Button rotateButton;
    public Button RetryButton;
    public Button RetryButton02;
    private bool isFinAnimals=false;
    private bool firstGene=true;

    public bool isFall;//生成された動物が落下中か

    private void Start()
    {
        
        Init();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Init()
    {
        mainCamera=Camera.main;
        animalNum = 0;
        isGameOver = false;

        Animal.isMoves.Clear();//移動してる動物のリストを初期化
        StartCoroutine(StateReset());
        rotateButton = GameObject.Find ("Canvas/rotateButton").GetComponent<Button> ();
        RetryButton= GameObject.Find ("Canvas/GameOverUI/RetryButton").GetComponent<Button>();
        RetryButton02= GameObject.Find ("Canvas/GameOverUI/RetryButton02").GetComponent<Button>();


        RetryButton.enabled=false;
        RetryButton02.enabled=false;
        
        isFinAnimals=true;
        isGene=false;

    }

    // 毎フレーム呼び出される(60fpsだったら1秒間に60回)
    void Update () {
        
        if (isGameOver & isFinAnimals)
        {
            RetryButton.enabled=true;
            RetryButton02.enabled=true;
            Debug.Log("Retry");
            return;//ゲームオーバーならここで止める
        }

        if (CheckMove(Animal.isMoves))
        {
            return;//移動中なら処理はここまで
        }

        if (isFall){
            rotateButton.enabled=false;
        }else{
            rotateButton.enabled=true;
        }

        if (!isGene)//生成されてるものがない
        {
            StartCoroutine(GenerateAnimal());//生成するコルーチンを動かす
            isGene = true;
            return;
        }

        Vector2 v;
        
        if(Input.mousePosition.x<0){
            return;
        }
        else if(Input.mousePosition.x>Screen.width) {
            return;
        }
        else{
            v = new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, pivotHeight);
        }

        if (Input.GetMouseButtonUp(0))//もし（マウス左クリックが離されたら）
        {
            if (!RotateButton.onButtonDown)//ボタンをクリックしていたら反応させない
            {
                geneAnimal.transform.position = v;
                geneAnimal.GetComponent<Rigidbody2D>().isKinematic = false;//――――物理挙動・オン
                animalNum++;//どうぶつ生成
                isFall = true;//落ちて、どうぞ
            }
            RotateButton.onButtonDown = false;//マウスが上がったらボタンも離れたと思う
        }
        else if(Input.GetMouseButton(0))//ボタンが押されている間
        {
            geneAnimal.transform.position = v;
        }
	}

    /// <summary>
    /// 生成・落下状態をリセットするコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator StateReset()
    {
        while (!isGameOver)
        {
            yield return new WaitUntil(() => isFall);//落下するまで処理が止まる
            yield return new WaitForSeconds(0.1f);//少しだけ物理演算処理を待つ（ないと無限ループ）
            
            isFall = false;
            isGene = false;

        }
        
    }
    
    /// <summary>
    /// どうぶつの生成コルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator GenerateAnimal()
    {
        while (CameraController.isCollision)
        {
            yield return new WaitForEndOfFrame();//フレームの終わりまで待つ（無いと無限ループ）
            mainCamera.transform.Translate(0,0.1f,0);//カメラを少し上に移動
            pivotHeight += 0.1f;//生成位置も少し上に移動
        }
        if(firstGene==false){
            if (underLim <= geneAnimal.transform.position.y & geneAnimal.transform.position.y < pivotHeight  ){
                mainCamera.transform.position=new Vector3(0.0f,mainCamera.transform.position.y+2.2f,mainCamera.transform.position.z);
                pivotHeight+=2.2f;
                underLim+=2.2f;
            }
        }
        
        geneAnimal = Instantiate(Resources.Load<GameObject>("test"+Random.Range(0, 6).ToString()), new Vector2(0, pivotHeight), Quaternion.identity);//回転せずに生成
        geneAnimal.GetComponent<Rigidbody2D>().isKinematic = true;//物理挙動をさせない状態にする
        firstGene=false;
    }

    /// <summary>
    /// どうぶつの回転
    /// ボタンにつけて使います
    /// </summary>
    public void RotateAnimal()
    {
        Debug.Log("rotate!");

        if(!isFall)
            Debug.Log("rotate!2");
            geneAnimal.transform.Rotate(0,0,-30);//30度ずつ回転
    }

    /// <summary>
    /// リトライボタン
    /// </summary>
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// 移動中かチェック
    /// </summary>
    /// <param name="isMoves"></param>
    /// <returns></returns>
    bool CheckMove(List<Moving> isMoves)
    {
        if (isMoves == null)
        {
            return false;
        }
        foreach (Moving b in isMoves)
        {
            if (b.isMove)
            {
                //Debug.Log("移動中(*'ω'*)");
                return true;
            }
        }
        return false;
    }
}