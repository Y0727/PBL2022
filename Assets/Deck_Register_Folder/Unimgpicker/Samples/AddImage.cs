using Kakera;
using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AddImage : MonoBehaviour
{
    [SerializeField] private Unimgpicker imagePicker;
    [SerializeField] private Image ssImage;
    public Texture2D texture;
    public static Sprite texture2;
    IEnumerator routine;
    public int pic_num;

    private void Awake()
    {
        
    }

    private void Start()
    {
        if (!ssImage)
        {
            ssImage = gameObject.GetComponent<Image>();
        }
    }
    
    
    

    public void OnPressShowPicker(int pic_num)
    {

        imagePicker.Completed += path => StartCoroutine(LoadImage(path, ssImage,pic_num));
        imagePicker.Show("Select Image", "unimgpicker", 512); //1024��512�ɕύX
        this.pic_num=pic_num;
        Invoke("callback",1.0f);
        
    }

    public void callback(){

        Debug.Log("1banme?");
        byte[] bytes = texture2.texture.EncodeToPNG();
        print("FileIS"+pic_num.ToString());
        File.WriteAllBytes("Assets/Deck_Register_Folder/Resources/a_test"+pic_num.ToString()+".png",bytes);
        print("FileSaveFin");        
        AssetDatabase.Refresh();
    }
    

    private IEnumerator LoadImage(string path, Image output,int pic_num)
    {
        string url = "file://" + path;
        WWW www = new WWW(url);
        yield return www;

        texture = www.texture;
        // �܂����T�C�Y
        int _CompressRate = TextureCompressionRate.TextureCompressionRatio(texture.width, texture.height);
        TextureScale.Bilinear(texture, texture.width / _CompressRate, texture.height / _CompressRate);
        // ���Ɉ��k(�c���E����������Ǝg���Ȃ��ꍇ������悤�ł��B) -> https://forum.unity.com/threads/strange-error-message-miplevel-m_mipcount.441907/
        //texture.Compress(false);
        // Sprite�ɕϊ����Ďg�p����

        texture2 = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        output.overrideSprite = texture2;
        
        Debug.Log("2banme?");

        

    }
}


public static class TextureCompressionRate
{
    /// <summary>
    /// Texture��500x500�Ɏ��܂�悤�Ƀ��T�C�Y���܂�
    /// </summary>
    public static int TextureCompressionRatio(int width, int height)
    {
        if (width >= height)
        {
            if (width / 500 > 0) return (width / 500);
            else return 1;
        }
        else if (width < height)
        {
            if (height / 500 > 0) return (height / 500);
            else return 1;
        }
        else return 1;
        Debug.Log("4banme");
    }
}