using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//ボタンを選択状態に設定する
public class SelectOnSelf : MonoBehaviour
{
    private Selectable sel;
    private void OnEnable()
    {
        sel = GetComponent<Selectable>();
        sel.Select();//選択状態に
    }
}