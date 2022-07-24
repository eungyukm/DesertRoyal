using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Card : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public UnityAction<int, Vector2> OnDragAction;
    public UnityAction<int> OnTapDownAction, OnTapReleaseAction;

    [HideInInspector] public int cardId;
    [HideInInspector] public CardData cardData;
    
    public Image portraitImage; //Inspector-set reference
    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void InitialiseWithData(CardData cData)
    {
        cardData = cData;
        portraitImage.sprite = cardData.cardImage;
    }

    public void OnPointerDown(PointerEventData pointerEvent)
    {
        if(OnTapDownAction != null)
            OnTapDownAction(cardId);
    }

    public void OnDrag(PointerEventData pointerEvent)
    {
        if(OnDragAction != null)
            OnDragAction(cardId, pointerEvent.delta);
    }

    public void OnPointerUp(PointerEventData pointerEvent)
    {
        if(OnTapReleaseAction != null)
            OnTapReleaseAction(cardId);
    }

    public void ChangeActiveState(bool isActive)
    {
        canvasGroup.alpha = (isActive) ? .05f : 1f;
    }
}
