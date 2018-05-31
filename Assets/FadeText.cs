using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ちょっとの間現れて消える3Dテキスト
/// </summary>
public class FadeText : MonoBehaviour
{

    private int remainFrame = 60;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        remainFrame--;
        if (remainFrame <= 0)
            Destroy(gameObject);
    }
}
