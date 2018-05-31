using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubeButton : MonoBehaviour
{

    /// <summary>
    /// 生み出すキューブの色
    /// </summary>
    public Cube.Color color = Cube.Color.Red;
    public Cube Prefab;

    public void OnClick()
    {
        var cube = Instantiate(Prefab);
        cube.SetColor(color);
    }
}
