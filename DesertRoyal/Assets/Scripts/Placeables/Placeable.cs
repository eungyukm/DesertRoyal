using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Placeable : MonoBehaviour
{
    public PlaceableType pType;
    public PlaceableTarget targetType;
    public UnityAction<Placeable> OnDie;
    public Faction faction;
    
    public enum PlaceableType
    {
        Obstacle,
        Building,
        Unit,
        Speel,
        Castle
    }
    
    public enum PlaceableTarget
    {
        None,
        OnlyBuildings,
        Both
    }
    
    public enum Faction
    {
        None,
        Player,
        Opponent
    }
}
