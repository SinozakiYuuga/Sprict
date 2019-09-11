using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/*シーン切り替え時のフェードイン、フェードアウトの設定
  Fade_managerと処理がかぶってる気がする（要再構成）*/
public class Game_manager : MonoBehaviour
{
    [SerializeField]
    private float time;
    private float fadeintime;
    private float fadeouttime;
    [SerializeField]
    private GameObject eventsystem;//キーの再入力防止用に使用
    //背景Image
    [SerializeField]
    private Image image;
    private string scene;
    // Update is called once per frame
    //フェードなし
    public void Onclick(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
    //フェードイン
    public void Onclick_fadein(string scene_name)
    {
        scene = scene_name;
        Application.targetFrameRate = 30;
        //　コルーチンで使用する待ち時間を計測
        fadeintime = 1f * time / 10f;
        eventsystem.SetActive(false);
        StartCoroutine("FadeIn");
       
    }
    //フェードアウト
    public void Onclick_fadeout(string scene_name)
    {
        scene = scene_name;
        fadeouttime = 1f * time / 10f;
        eventsystem.SetActive(false);
        StartCoroutine("FadeOut");
    }
    IEnumerator FadeIn()
    {
        //　Colorのアルファを0.1ずつ上げていく
        for (var i = 0f; i <= 1f; i += 0.1f)
        {
            image.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(fadeintime);//指定秒数待つ
        }
        SceneManager.LoadScene(scene);
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
        SceneManager.LoadScene(scene);
    }
}
