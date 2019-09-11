using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*マイマイを動かすスクリプト*/
public class Character : MonoBehaviour
{
    private int move_speed = 2;//移動量
    private float jumpforce = 350;//ジャンプ力
    private float move;//移動向き
    private float respawn_x, respawn_y;//復活位置
    private bool isground;
    private bool spece_on = false;
    public bool can_move = true;
    private Rigidbody2D rb;
    private CapsuleCollider2D c_collider;
    private SpriteRenderer s_renderer;
    private AudioSource audioSouce;
    private Animator animator;
    [SerializeField]
    private PhysicsMaterial2D[] materials;//動く床と普通の床によってmaterialを変更するための配列
    [SerializeField]
    private bool isgoal;//ゴール判定
    [SerializeField]
    private bool isenemy;
    [SerializeField]
    private string goal_tag;
    [SerializeField]
    private GameObject fadeout;
    [SerializeField]
    private GameObject fadein;
    [SerializeField]
    private AudioClip jump_sound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSouce = GetComponent<AudioSource>();
        c_collider = GetComponent<CapsuleCollider2D>();
        s_renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //初期位置をりスポーン地点に
        respawn_x = transform.position.x;
        respawn_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //ステージ名表示中はジャンプを受け付けない
        if (isground && Input.GetKeyDown(KeyCode.Space) && Isfadenow() && spece_on)
        {
            Jump();
        }
        if (!spece_on && Input.GetKeyDown(KeyCode.Space))
        {
            spece_on = true;
        }
    }
    private void FixedUpdate()
    {
        //ステージ名表示中、移動禁止設定有効ならば受け付けない
        if (Isfadenow()&&can_move)
        { 
            move = Input.GetAxisRaw("Horizontal");
            if (move > 0)
            {
                s_renderer.flipX = true;
                animator.SetBool("Walk", true);
            }
            else if (move < 0)
            {
                s_renderer.flipX = false;
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
            if (move == 0&&isground)
            {
                c_collider.sharedMaterial = materials[0];
            }
            else
            {
                c_collider.sharedMaterial = materials[1];
            }
            if (Input.GetKey(KeyCode.C))
            {
                move *= (isenemy) ? -2 : 2;//ヤミーの場合は動きが反転
                if (isenemy&&move < 0)
                {
                    s_renderer.flipX = false;//画像の反転の判断
                }
                else if (isenemy && move > 0)
                {
                    s_renderer.flipX = true;
                }
                animator.SetBool("Dash", true);
            }
            else
            {
                animator.SetBool("Dash", false);
            }
            rb.velocity = new Vector2(move * move_speed, rb.velocity.y);
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpforce);
        isground = false;
        audioSouce.PlayOneShot(jump_sound);
    }
    public void Respawn()
    {
        transform.position = new Vector3(respawn_x, respawn_y,-1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respaw_point")
        {
            Respawn();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isground = false;
        isgoal = false;
        transform.SetParent(null);
        animator.SetBool("Ground", false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //床またはゴールのとき
        if (collision.gameObject.tag.Contains("Ground") || collision.gameObject.tag.Contains("Goal"))
        {
            isground = true;
            animator.SetBool("Ground", true);
        }
        //動く床
        if (collision.gameObject.tag == "Move_Ground")
        {
            transform.SetParent(collision.transform);
            
        }
        //ゴール判定
        if (collision.gameObject.tag == goal_tag && rb.velocity.x == 0 && isground)
        {
            isgoal = true;
        }
        else
        {
            isgoal = false;
        }
    }
    public bool Isgoal()
    {
        return isgoal;
    }
    private bool Isfadenow()
    {
        return !(fadeout.activeSelf || fadein.activeSelf);
    }
}
