using Kakera;
using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


// 個人的に思ってるのは、一旦画像を読み込んでファイルの保存、
// どのボタンが押されたかを取得して、それに対応した写真の保存先に写真を保存する
// 保存した場所から写真を取得してボタンの画像を変える？

"""
動き方
Awake
Start
ボタン押した時
OnPressShowPicker
"""

public class AddImage : MonoBehaviour
{
    [SerializeField] private Unimgpicker imagePicker;
    [SerializeField] private Image ssImage;
    public Texture2D texture;
    public Sprite texture2;

    // ssImageに選択されているgameObjectを選択
    // 2. 次にこいつ
    private void Start()
    {
        ssImage = gameObject.GetComponent<Image>();
        Debug.Log("aa");
    }

    // imagePicker
    // 1. 最初にこいつ
    private void Awake()
    {
        imagePicker.Completed += path => StartCoroutine(LoadImage(path, ssImage));
        Debug.Log("bb");
        // 保存先をなんとかしたい
    }

    // 3. 次にこいつ
    public void OnPressShowPicker()
    {
        imagePicker.Show("Select Image", "unimgpicker", 512);
        Debug.Log("cc");
    }

    // ここで、textureが一つしかないから全部同じ場所が書き変わるのかな？
    // 
    private IEnumerator LoadImage(string path, Image output)
    {
        string url = "file://" + path;
        WWW www = new WWW(url);
        yield return www;
        texture = www.texture;
        Debug.Log(texture);
        // �܂����T�C�Y
        int _CompressRate = TextureCompressionRate.TextureCompressionRatio(texture.width, texture.height);
        TextureScale.Bilinear(texture, texture.width / _CompressRate, texture.height / _CompressRate);
        // ���Ɉ��k(�c���E����������Ǝg���Ȃ��ꍇ������悤�ł��B) -> https://forum.unity.com/threads/strange-error-message-miplevel-m_mipcount.441907/
        //texture.Compress(false);
        // Sprite�ɕϊ����Ďg�p����
        texture2 = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        output.overrideSprite = texture2;

        // Debug.Log(ssImage.texture2.texture.EncodeToPNG());
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
    }
}