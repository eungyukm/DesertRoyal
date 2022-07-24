using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Unity Royale/Card Data")]
public class CardData : ScriptableObject
{
    [Header("Card graphics")]
    public Sprite cardImage;

    // 이 카드가 생성하는 모든 플레이스테이블에 연결
    [Header("List of Placeables")]
    public PlaceableData[] placeablesData;
    
    //장소 테이블이 놓일 상대 간격띄우기(커서에서)
    public Vector3[] relativeOffsets;
}
