using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//マイマイ側の追加処理（characterスクリプトを参照）
public class Player : Character
{
    [SerializeField]
    private AudioClip die_sound;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }
    private void Die()
    {
        AudioSource.PlayClipAtPoint(die_sound, transform.position);
        gameObject.SetActive(false);
    }
}
