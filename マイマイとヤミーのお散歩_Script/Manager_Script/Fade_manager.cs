using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*フェードイン、フェードアウトの管理を行う
  またクリア、ゲームオーバーの判定等も行うため実質Game_manager状態と言っても過言ではない
  (要分割化部分)*/

public class Fade_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject fadein;
    [SerializeField]
    private GameObject fadeout;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Text text;//ステージ名のtext格納
    [SerializeField]
    private AudioClip clear_sound;
    [SerializeField]
    private GameObject bgm_fadein;
    [SerializeField]
    private GameObject gameover_canvas;
    [SerializeField]
    private GameObject clear_canvas;
    [SerializeField]
    private Image image;//暗幕パネル
    private Player player_script;
    private Character enemy_script;
    private AudioSource audioSouce;
    private Bgm_fadein bgm_script;
    private bool isfadein = false;//フェードインした？
    private bool iskeydown = false;//ボタンは押された？
    private bool isclear = false;//クリアした？
    private bool isexecution = false;//処理した？

    private void Start()
    {
        player_script = player.GetComponent<Player>();
        enemy_script = enemy.GetComponent<Character>();
        audioSouce = GetComponent<AudioSource>();
        bgm_script = bgm_fadein.GetComponent<Bgm_fadein>();
    }
    private void Update()
    {
        Fadeout();
        Die();
        Clear();
    }
    private void Fadein()
    {
        if (!isfadein)
        {
            fadein.SetActive(true);
            bgm_script.Fadein();
        }
        if (!fadein.activeSelf)
        {
            if (isclear)//ゲームオーバー
            {
                isexecution = true;
                image.color = new Color(image.color.r, image.color.g, image.color.b,0f);
                clear_canvas.SetActive(true);
                player_script.can_move = false;
                enemy_script.can_move = false;

            }
            else if (!isexecution)//クリア
            {
                enemy.SetActive(false);
                player.SetActive(false);
                gameover_canvas.SetActive(true);
              
            }
        }
    }
    private void Fadeout()
    {
        if (Input.GetKeyDown("space") && !iskeydown)
        {
            bgm_script.bgm.Play();
            iskeydown = true;
            fadeout.SetActive(true);
            text.gameObject.SetActive(false);
        }
    }
    private void Clear()
    {
        if (player_script.Isgoal() && enemy_script.Isgoal())
        {
            Fadein();
            if (!isfadein)
            {
                audioSouce.PlayOneShot(clear_sound);
                isexecution = true;
                isclear = true;
            }
            isfadein = true;
        }
    }
    private void Die()
    {
        if (!player.activeSelf)
        {
            Fadein();
            isfadein = true;
        }
    }

}
