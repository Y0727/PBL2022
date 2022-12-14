using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;//UI系をいじるときに必要なusing

namespace Kakera
{
   public class PickerController : MonoBehaviour
   {
       [SerializeField]
       private Unimgpicker imagePicker;

       [SerializeField]
       private GameObject RawimagePrefab; //GameObjectで参照してくる

       [SerializeField]
       private GameObject canvas;//Canvasも参照

       void Awake()
       {
           imagePicker.Completed += (string path) =>
           {
               StartCoroutine(LoadImage(path, RawimagePrefab));
           };
       }

       //=================================================
       //ボタンを押したときに発動
       //=================================================
       public void OnPressShowPicker()
       {
           imagePicker.Show("Select Image", "unimgpicker", 512);
       }

       private IEnumerator LoadImage(string path, GameObject output)
       {
           var url = "file://" + path;

           var unityWebRequestTexture = UnityWebRequestTexture.GetTexture(url);

           yield return unityWebRequestTexture.SendWebRequest();

           var texture = ((DownloadHandlerTexture)unityWebRequestTexture.downloadHandler).texture;
           if (texture == null)
           {
               Debug.LogError("Failed to load texture url:" + url);
           }

           output.GetComponent<RawImage>().texture = texture;

           GameObject prefab = (GameObject)Instantiate(output);

           prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(output.GetComponent<RawImage>().texture.width / 10, output.GetComponent<RawImage>().texture.height / 10);
           prefab.transform.SetParent(canvas.transform, false);
       }
   }
}









