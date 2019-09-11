using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//背景の雲を動かす
public class Back_Ground_Move : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = -0.01f;//移動速度
    private Vector3 start_pos;//移動スタート位置
    private Vector3 goal_pos;//移動終了位置
    private Vector3 pos;//現在位置
    void Start()
    {
        start_pos = Camera.main.ViewportToWorldPoint(Vector3.one);
        goal_pos = Camera.main.ViewportToWorldPoint(Vector3.zero);
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        pos = transform.position;
        pos.x += speed;
        transform.position = pos;
    }
    private void Update()
    {
        if (goal_pos.x-1> pos.x)
        {
            pos.x = start_pos.x+1;
            transform.position = pos;
        }
    }
}
