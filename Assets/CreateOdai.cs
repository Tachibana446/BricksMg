using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// お題パネルにお題を生み出す
/// </summary>
public class CreateOdai : MonoBehaviour
{
    public List<Odai> OdaiList = new List<Odai>();
    private Odai nowOdai = null;

    // Use this for initialization
    void Start()
    {
        var prefab = OdaiList[Random.Range(0, OdaiList.Count)];
        var obj = Instantiate(prefab.gameObject, this.transform);
        nowOdai = obj.GetComponent<Odai>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OdaiList.Count == 0) return;

        if (nowOdai.IsClear)
        {
            Debug.Log("お題を更新");
            Destroy(nowOdai.gameObject);
            var prefab = OdaiList[Random.Range(0, OdaiList.Count)];
            var obj = Instantiate(prefab.gameObject, this.transform);
            nowOdai = obj.GetComponent<Odai>();
        }
    }

    /// <summary>
    /// お題を引き直す
    /// </summary>
    public void ReloadOdai()
    {
        Destroy(nowOdai.gameObject);
        var prefab = OdaiList[Random.Range(0, OdaiList.Count)];
        var obj = Instantiate(prefab.gameObject, this.transform);
        nowOdai = obj.GetComponent<Odai>();
    }
}
