using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面のキューブを全消去するスクリプト
/// </summary>
public class ClearCubes : MonoBehaviour
{
    public void OnClick()
    {
        foreach (var cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            Destroy(cube);
        }
    }
}
