using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablesExample : MonoBehaviour
{
    public AssetReference AssetReference;
    // Start is called before the first frame update
    void Start()
    {
        AssetReference.LoadAssetAsync<GameObject>();
        AssetReference.InstantiateAsync(Vector3.zero, Quaternion.identity);
    }
}
