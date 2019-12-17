using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorUI : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        target.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite.texture);
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
            Debug.Log(target.name);
        }
    }
}
