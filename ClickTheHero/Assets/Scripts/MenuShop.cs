using UnityEngine;
using UnityEngine.EventSystems;

public class ShopController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform shopRectTransform;
    public float shopVisiblePosition;
    public float shopHiddenPosition;
    public float moveSpeed = 10f;

    private bool isMouseOverShop;

    private void Update()
    {
        float targetPosition = isMouseOverShop ? shopVisiblePosition : shopHiddenPosition;
        float currentX = shopRectTransform.localPosition.x;

        // Move towards the target position
        float newX = Mathf.MoveTowards(currentX, targetPosition, Time.deltaTime * moveSpeed);
        shopRectTransform.localPosition = new Vector3(newX, shopRectTransform.localPosition.y, shopRectTransform.localPosition.z);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOverShop = true;
        Debug.Log("Mouse entered shop");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOverShop = false;
        Debug.Log("Mouse exited shop");
    }
}
