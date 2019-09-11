using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//チュートリアルコースでのUI表示・非表示切り替え
public class Tutorial : MonoBehaviour
{
    [SerializeField]
    GameObject Canvas;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Canvas.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Canvas.SetActive(false);
    }
}
