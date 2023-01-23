using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class To_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    //押されたときに遷移するやつ
    public void ToGame()
    {
        for(int i=0;i<=5;i++){
            //image[1].rectTransform.rect.width;
            Sprite sprite_t = Resources.Load<Sprite>("a_test"+i.ToString()) as Sprite;
            GameObject test = new GameObject("test"+i.ToString());
            test.AddComponent<SpriteRenderer>();
            test.GetComponent<SpriteRenderer>().sprite=sprite_t;
            test.AddComponent<PolygonCollider2D>();
            test.AddComponent<Rigidbody2D>();
            test.AddComponent<Animal>();
            //test.GetComponent<Image>
            float width = test.GetComponent<SpriteRenderer>().bounds.size.x;
            float height = test.GetComponent<SpriteRenderer>().bounds.size.y;

            while(width > 1.8f | height > 1.8f){
                
                width= width/2.0f;
                
                height=height/2.0f;
                
            }
            
            print(width);
            print(height);
            test.transform.localScale = new Vector3 (width, height);
            
            string localPath = "Assets/Deck_Register_Folder/Resources/" + test.name + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(test, localPath);
            AssetDatabase.Refresh();
            test.transform.position=new Vector2(100,100);
            
        }
        SceneManager.LoadScene("VS_Ryu");

    }
}
