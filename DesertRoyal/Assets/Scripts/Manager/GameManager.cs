using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool autoStart = false;
    public CardManager cardManager;
    public GameObject playersCastle, opponentCastle;

    private void Awake()
    {
        cardManager = GetComponent<CardManager>();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        cardManager.LoadDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
