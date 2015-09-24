using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 事件触发封装给gameObject添加交互事件 - 需要什么事件可扩展 
/// Event trigger listener.
/// </summary>
public class EventTriggerListener : MonoBehaviour,  
                                    IPointerClickHandler,  
                                    IPointerDownHandler,  
                                    IPointerEnterHandler,  
                                    IPointerExitHandler,  
                                    IPointerUpHandler,  
                                    ISelectHandler,  
                                    IUpdateSelectedHandler,  
                                    IDeselectHandler,
                                    IDragHandler,
                                    IEndDragHandler,
                                    IDropHandler,
                                    IScrollHandler,
                                    IMoveHandler
{
    public delegate void VoidDelegate (GameObject go);
    public VoidDelegate onClick;
    public VoidDelegate onDown;
    public VoidDelegate onEnter;
    public VoidDelegate onExit;
    public VoidDelegate onUp;
    public VoidDelegate onSelect;
    public VoidDelegate onUpdateSelected;
    public VoidDelegate onDeselect;
    public VoidDelegate onDrag;
    public VoidDelegate onEndDrag;
    public VoidDelegate onDrop;
    public VoidDelegate onScroll;
    public VoidDelegate onMove;

    static public EventTriggerListener Get (GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(onClick != null) onClick(gameObject);
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        if(onDown != null) onDown(gameObject);
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        if(onEnter != null) onEnter(gameObject);
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        if(onExit != null) onExit(gameObject);
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        if(onUp != null) onUp(gameObject);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect(gameObject);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelected != null) onUpdateSelected(gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (onDeselect != null) onDeselect(gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (onDrag != null) onDrag(gameObject);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDrag != null) onEndDrag(gameObject);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (onDrop != null) onDrop(gameObject);
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (onScroll != null) onScroll(gameObject);
    }

    public void OnMove(AxisEventData eventData)
    {
        if (onMove != null) onMove(gameObject);
    }
}