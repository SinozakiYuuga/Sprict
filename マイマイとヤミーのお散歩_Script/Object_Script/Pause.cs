using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*ポーズ画面
　　担当者　篠﨑*/
public class Pause : MonoBehaviour
{
	//　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private Image panel;
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))&&panel.color.a <= 0f)
        {
            if (!pauseUI.activeSelf)//ポーズ画面じゃないなら
            {
                pauseUI.SetActive(true);//UI表示
                Time.timeScale = 0f;//ゲーム進行速度を0に
            }
            else
            {
                pauseUI.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
    public void Pause_cancel()
    {
        Time.timeScale = 1f;
    }
}