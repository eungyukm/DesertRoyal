using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DeckLoader : MonoBehaviour
{
    private DeckData targetDeck;
    public UnityAction OnDeckLoaded;

    public void LoadDeck(DeckData deckToLoad)
    {
        targetDeck = deckToLoad;
        Addressables.LoadAssetsAsync<CardData>(targetDeck.labelsToInclude[0].labelString, null).Completed += OnResourcesRetrieved;
    }

    private void OnResourcesRetrieved(AsyncOperationHandle<IList<CardData>> obj)
    {
        targetDeck.CardsRetrieved((List<CardData>)obj.Result);

        if(OnDeckLoaded != null)
            OnDeckLoaded();

        Destroy(this);
    }
}
