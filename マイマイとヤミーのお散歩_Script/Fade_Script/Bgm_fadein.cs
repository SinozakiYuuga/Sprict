using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*BGMのフェードインを行う*/
public class Bgm_fadein : MonoBehaviour
{
    //フェードインのおおよその秒数
    [SerializeField]
    private float fadeintime;
    //フェードインをさせるBGM
    public AudioSource bgm;
    private void Start()
    {
        bgm = GetComponent<AudioSource>();
    }
    public void Fadein()
    {
        //　コルーチンで使用する待ち時間を計測
        fadeintime = 1f * fadeintime / 10f;
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        //　音量を0.1ずつ上げていく
        for (var i = 0f; i <= 1f; i += 0.1f)
        {
            bgm.volume -= i;
            yield return new WaitForSeconds(fadeintime);//指定秒数待つ
        }
        gameObject.SetActive(false);
    }
}
