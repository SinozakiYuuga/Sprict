using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//落下する床の判定について
public class TriggerObject : MonoBehaviour
{
    private bool ison = false;
    private bool callfixed = false;

    public bool Isplayeron()
    {
         return ison;
    }
    private void FixedUpdate()
    {
        callfixed = true;
    }

    private void LateUpdate()
    {
        if (callfixed)
        {
            ison = false;
            callfixed  = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy"|| collision.tag == "Player")
        {
            ison = true;
        }
    }

}
