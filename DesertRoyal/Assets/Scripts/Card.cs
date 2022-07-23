using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Camera mainCamera;
    public GameObject Unit;
    public LayerMask LayerMask;

    public GameObject placeHolder;

    public GameObject card;
    
    [HideInInspector] public int cardId;
    [HideInInspector] public CardData cardData;
    public Image portraitImage; //Inspector-set reference
    
    // Start is called before the first frame update
    void Start()
    {
        placeHolder = Instantiate(Unit, Vector3.zero, Quaternion.identity);
        placeHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag!!");
        transform.position = eventData.position;
        
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask))
        {
            Vector3 hitPos = hit.point;
            placeHolder.SetActive(true);
            card.SetActive(false);
            placeHolder.transform.position = hitPos;
        }
        else
        {
            card.SetActive(true);
            placeHolder.SetActive(false);
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
    
    public void InitialiseWithData(CardData cData)
    {
        cardData = cData;
        portraitImage.sprite = cardData.cardImage;
    }
}
