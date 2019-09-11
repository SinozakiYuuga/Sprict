using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ゲーム終了の管理をする*/
public class Gameend_manager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;//デバッグモード時終了
            #else
			    Application.Quit();//ゲームの終了
            #endif
        }
    }
}
