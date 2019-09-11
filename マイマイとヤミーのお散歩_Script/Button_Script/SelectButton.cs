using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*ステージ選択時にステージ画像を表示する*/
public class SelectButton : MonoBehaviour
{
    private GameObject select_button;//選択状態のボタンを格納
    [SerializeField]
    private GameObject button;//このスクリプトのついているゲームオブジェクトを格納
    [SerializeField]
    private Image image;//ステージ画像
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        /*Spaceキー連続押しによるフェードイン、アウトの重複処理防止のためイベントシステムを
          非アクティブ化するため、イベントシステムがないというエラーを例外でnullにしている。*/
        try
        {
            select_button = EventSystem.current.currentSelectedGameObject;
        }
        catch
        {
            select_button = null;
        }
        //選択状態のボタンとこのスクリプトのついているボタンが同じ場合透明度を変更してステージ画像を表示
        if (select_button != null)
        {
            if (select_button == button)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
            }
            else
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
            }
        }
    }
}
