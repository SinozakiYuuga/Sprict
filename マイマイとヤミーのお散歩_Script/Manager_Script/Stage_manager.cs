using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*ステージ名表示
  なくてもいいかもしれない*/
public class Stage_manager : MonoBehaviour
{
    [SerializeField]
    private Text canvas;
    [SerializeField]
    private string stage_name;
    void Start()
    {
        Text text = canvas.GetComponent<Text>();
        text.text = stage_name;
    }
}
