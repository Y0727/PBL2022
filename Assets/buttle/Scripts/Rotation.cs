using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    /// <summary>
    /// Z軸を基点に回転する速さ
    /// </summary>
    [SerializeField]
    private float rotAngleZ = 1f;

    float rotation_speed = 1; // 回転速度

    void Update()
    {
        // フレームごとに回転させる
        transform.Rotate(0, 0, rotAngleZ);
    }
}