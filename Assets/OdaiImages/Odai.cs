using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 組み立てるべきお題
/// </summary>
public class Odai : MonoBehaviour
{
    /// <summary>
    /// タイトル
    /// </summary>
    public Name weaponName = Name.FireDagger;
    /// <summary>
    /// クリアしたかどうか
    /// </summary>
    public bool IsClear = false;

    public GameObject OKTextPrefab = null;

    /// <summary>
    /// 達成しているフレーム数
    /// これが120を超えたらクリアとする
    /// </summary>
    private int clearCount = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsClear)
            return;
        switch (weaponName)
        {
            case Name.FireDagger:
                CheckFireDagger();
                break;
            case Name.FlamIgnis:
                CheckFlamIgnis();
                break;
            default:
                break;
        }
        // クリア処理
        if (clearCount > 180)
        {
            IsClear = true;
            if (OKTextPrefab)
                Instantiate(OKTextPrefab);
        }
    }

    /// <summary>
    /// 赤キューブが3つ縦に並んでるやつ
    /// </summary>
    private void CheckFireDagger()
    {
        var _cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cube"));
        var cubes = _cubes.Select(c => c.GetComponent<Cube>()).Where(c => c.color == Cube.Color.Red).ToList();
        bool clear = false;
        foreach (var cube in cubes)
        {
            if (cubes.Count(c => c.GetInstanceID() != cube.GetInstanceID() && c.transform.position.y + 0.9 < cube.transform.position.y) >= 2)
            {
                clear = true;
                break;
            }
        }
        if (clear)
            clearCount++;
        else
            clearCount = 0;
    }
    /// <summary>
    /// 縦に長いややこしいやつ
    /// </summary>
    private void CheckFlamIgnis()
    {
        bool clear = false;
        var cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cube")).Select(c => c.GetComponent<Cube>()).ToList();
        foreach (var yellow in cubes.Where(c => c.color == Cube.Color.Yellow))
        {
            if (!cubes.Any(c => c.color == Cube.Color.Yellow &&
             yellow.GetInstanceID() != c.GetInstanceID() &&
             yellow.transform.position.x + 0.9 < c.transform.position.x))
                break;

            Debug.Log("黄色があるよ");

            foreach (var purple in cubes.Where(c => c.color == Cube.Color.Purple && yellow.transform.position.y + 0.9 < c.transform.position.y))
            {
                Debug.Log("紫もあるよ");
                foreach (var red in cubes.Where(
                    c => c.color == Cube.Color.Red && purple.transform.position.y + 0.9 > c.transform.position.y &&
                    cubes.Any(c2 => c2.color == Cube.Color.Red && c.GetInstanceID() != c2.GetInstanceID() && c.transform.position.x + 0.5 < c2.transform.position.x)))
                {
                    Debug.Log("赤もあるよ");
                    if (cubes.Count(c => c.color == Cube.Color.Red && c.GetInstanceID() != red.GetInstanceID() && red.transform.position.y + 0.9 < c.transform.position.y) >= 3)
                        clear = true;
                }
            }
        }
        if (clear)
            clearCount++;
        else
            clearCount = 0;
    }

    public enum Name
    {
        FireDagger, FlamIgnis
    }
}
