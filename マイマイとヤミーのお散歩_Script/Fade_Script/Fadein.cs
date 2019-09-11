using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*ゲーム画面からだんだん暗幕に映る
　　作成者　篠﨑*/
  
public class Fadein : MonoBehaviour
{
    //フェードインのおおよその秒数
    [SerializeField]
    private float time;
    private float fadeintime;
    //背景Image
    [SerializeField]
    private Image image;

    void OnEnable()
    {
        Application.targetFrameRate = 30;
        //　コルーチンで使用する待ち時間を計測
        fadeintime = 1f * time / 10f;
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        //　Colorのアルファを0.1ずつ上げていく
        for (var i = 0f; i <= 1f; i += 0.1f)
        {
            image.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(fadeintime);//指定秒数待つ
        }
        gameObject.SetActive(false);
    }
}