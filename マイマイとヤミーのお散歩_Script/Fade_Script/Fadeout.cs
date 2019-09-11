using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*暗幕からだんだんとゲーム画面が映る
作成者　篠﨑　*/
public class Fadeout : MonoBehaviour
{
    //　フェードアウトのおおよその秒数
    [SerializeField]
    private float time;
    private float fadeouttime;
    //　背景Image
    [SerializeField]
    private Image image;

  
    private void OnEnable()
    {
        fadeouttime = 1f * time / 10f;
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        //　Colorのアルファを0.1ずつ下げていく
        for (var i = 1f; i >= -0.1f; i -= 0.1f)
        {
            image.color = new Color(0f, 0f, 0f, i);
            //　指定秒数待つ
            yield return new WaitForSeconds(fadeouttime);
        }
        gameObject.SetActive(false);
    }
}