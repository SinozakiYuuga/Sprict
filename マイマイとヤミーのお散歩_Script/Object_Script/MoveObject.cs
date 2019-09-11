using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//動く床の挙動について
public class MoveObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] movepoint;//移動ポイントを格納
    [SerializeField]
    private float speed = 2.0f;//移動速度
    private int nowpoint = 0;//現在通過しているポイント
    private int nextpoint = 0;//次のポイント
    private Rigidbody2D rb;
    private bool returnpoint = false;//折り返しているか？
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!returnpoint)
        {
            nextpoint = nowpoint + 1;
            if (Vector2.Distance(transform.position,movepoint[nextpoint].transform.position) > 0.1f)
            {
                Vector2 tovector = Vector2.MoveTowards(transform.position, movepoint[nextpoint].transform.position, speed * Time.deltaTime);
                rb.MovePosition(tovector);
            }
            else
            {
                rb.MovePosition(movepoint[nextpoint].transform.position);
                nowpoint += 1;
                if (nowpoint+1>=movepoint.Length)
                {
                    returnpoint = true;
                }
            }
        }
        else
        {
            nextpoint = nowpoint - 1;
            if (Vector2.Distance(transform.position, movepoint[nextpoint].transform.position) > 0.1f)
            {
                Vector2 tovector = Vector2.MoveTowards(transform.position, movepoint[nextpoint].transform.position, speed * Time.deltaTime);
                rb.MovePosition(tovector);
            }
            else
            {
                rb.MovePosition(movepoint[nextpoint].transform.position);
                nowpoint -= 1;
                if (nowpoint <= 0)
                {
                    returnpoint = false;
                }
            }
        }
    }
}
