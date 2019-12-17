using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 上色
/// </summary>
public class ColorManager : MonoBehaviour, IPointerClickHandler
{
    #region SetColor

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text == "0")
        {
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().raycastTarget = false;
            return;
        }
        target.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",
           eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.texture);
        switch (eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text)
        {
            case "8":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "7"; break;
            case "7":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "6"; break;
            case "6":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "5"; break;
            case "5":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "4"; break;
            case "4":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "3"; break;
            case "3":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "2"; break;
            case "2":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "1"; break;
            case "1":
                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).GetComponent<Text>().text = "0"; break;
        }
        #region MyRegion
        //switch (target.GetComponent<MeshRenderer>().material.name.ToString())
        //{
        //    case "Blue":
        //        target.GetComponent<CubeBase>().CubeColor = CubeColor.BLUE;
        //        break;
        //    case "Green":
        //        target.GetComponent<CubeBase>().CubeColor = CubeColor.GREEN;
        //        break;
        //    case "Orange":
        //        target.GetComponent<CubeBase>().CubeColor = CubeColor.ORANGE;
        //        break;
        //    case "Red":
        //        target.GetComponent<CubeBase>().CubeColor = CubeColor.RED;
        //        break;
        //    case "White":
        //        target.GetComponent<CubeBase>().CubeColor = CubeColor.WHITE;
        //        break;
        //    case "Yellow":
        //        target.GetComponent<CubeBase>().CubeColor = CubeColor.YELLOW;
        //        break;
        //}
        #endregion
    }

    GameObject target;
    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            target = hit.collider.gameObject;
        }


        if (CanvasGroup.alpha != targetAlpha)
        {
            CanvasGroup.alpha = Mathf.Lerp(CanvasGroup.alpha, targetAlpha, smootSpeed * Time.deltaTime);
            if (Mathf.Abs(CanvasGroup.alpha - targetAlpha) <= 0.05f)
            {
                CanvasGroup.alpha = targetAlpha;
            }
        }
    }

    #endregion


    #region 渐隐渐显
    //目标值
    private float targetAlpha = 1;
    //组件
    private CanvasGroup CanvasGroup;
    //速度
    private float smootSpeed = 4f;

    /// <summary>
    /// 渐显
    /// </summary>
    private void Show()
    {
        targetAlpha = 1f;
        CanvasGroup.blocksRaycasts = true;
    }
    /// <summary>
    /// 渐隐
    /// </summary>
    private void Hide()
    {
        targetAlpha = 0;
        CanvasGroup.blocksRaycasts = false;
    }
    public void DisPlaySwith()
    {
        if (CanvasGroup.alpha == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    #endregion

}
