using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Camera mainCamera;
    /// <summary>
    /// キューブの色
    /// </summary>
    public Color color;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        var pos = new Vector3();
        pos.x = eventData.pointerCurrentRaycast.worldPosition.x;
        pos.y = eventData.pointerCurrentRaycast.worldPosition.y;
        pos.z = 0;

        /*var p = mainCamera.ScreenToWorldPoint(eventData.position);
        pos.x = p.x; pos.y = p.y;
        */
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        var pos = new Vector3();
        pos.x = eventData.pointerCurrentRaycast.worldPosition.x;
        pos.y = eventData.pointerCurrentRaycast.worldPosition.y;
        pos.z = 0;

        transform.position = pos;
        Debug.Log("Drag End.");
    }

    /// <summary>
    /// クリックイベント
    /// 右クリック時にブロックを消去
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            Destroy(gameObject);
    }

    /// <summary>
    /// 色を決定
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color)
    {
        this.color = color;
        // Change Material
        switch (color)
        {
            case Color.Blue:
                gameObject.GetComponent<Renderer>().material.color = UnityEngine.Color.blue;
                break;
            case Color.Green:
                gameObject.GetComponent<Renderer>().material.color = UnityEngine.Color.green;
                break;
            case Color.Yellow:
                gameObject.GetComponent<Renderer>().material.color = UnityEngine.Color.yellow;
                break;
            case Color.Purple:
                gameObject.GetComponent<Renderer>().material.color = new UnityEngine.Color(1, 0, 1);
                break;
            default:
                break;
        }

    }

    public enum Color
    {
        Red, Blue, Green, Yellow, Purple
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
