using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*一定時間後に落下する床*/
public class FallDownGround : MonoBehaviour
{
    [SerializeField]
    private GameObject spriteobj;//床の画像データのゲームオブジェクト
    [SerializeField]
    private TriggerObject trigger;//判定データのゲームオブジェクト
    [SerializeField]
    private float vibrationwidth = 0.05f;//床の揺れ幅
    [SerializeField]
    private float vibrationspeed = 30.0f;//揺れの速度
    [SerializeField]
    private float falltime = 1.0f;//落下時間
    [SerializeField]
    private float fallspeed = 10.0f;//落下速度
    [SerializeField]
    private float returentime = 5.0f;//復帰時間

    //タイマー関連
    private float timer = 0.0f;
    private float fallingtime = 0.0f;
    private float returentimer = 0.0f;
    private float blinktimer = 0.0f;
    //フラグ判定
    private bool ison;//検知トリガー
    private bool isfall;//落下トリガー
    private bool isreturn;//復帰トリガー

    private Vector3 spritedefaultpos;
    private Vector3 floordefaultpos;
    private Vector2 fallvelocity;
    private BoxCollider2D col;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
   

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = spriteobj.GetComponent<SpriteRenderer>();
        fallvelocity = new Vector2(0, -fallspeed);
        spritedefaultpos = spriteobj.transform.position;
        floordefaultpos = gameObject.transform.position; 
    }

    void Update()
    {
        if (trigger.Isplayeron())
        {
            ison = true;
        }
        if (ison&&!isfall)
        {
            spriteobj.transform.position = spritedefaultpos + new Vector3(Mathf.Sin(timer * vibrationspeed) * vibrationwidth, 0, 0);
            if (timer > falltime)
            {
                isfall = true;
            }
            timer += Time.deltaTime;
        }
        if(isreturn)
        {
            if (blinktimer > 0.2f)
            {
                sr.enabled = true;
                blinktimer = 0.0f;
            }
            else if (blinktimer > 0.1f)
            {
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }
            if (returentimer > 1.0f)
            {
                isreturn = false;
                blinktimer = 0f;
                returentimer = 0f;
                sr.enabled = true;
            }
            else
            {
                blinktimer += Time.deltaTime;
                returentimer += Time.deltaTime;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isfall)
        {
            rb.velocity = fallvelocity;
            if (fallingtime > falltime)
            {
                isreturn = true;
                transform.position = floordefaultpos;
                rb.velocity = Vector2.zero;
                isfall = false;
                timer = 0.0f;
                fallingtime = 0.0f;
            }
            else
            {
                fallingtime += Time.deltaTime;
                ison = false;
            }
        }
    }
}
