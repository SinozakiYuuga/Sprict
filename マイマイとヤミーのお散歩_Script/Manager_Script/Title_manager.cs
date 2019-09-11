using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FPS設定やマウスカーソルの非表示
public class Title_manager : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.visible = false;
    }
}