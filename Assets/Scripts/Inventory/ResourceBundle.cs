using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Resource
{
    Gold,
    Silver,
    Food,
    Culture,
    Wood,
    Stone,
    Wool,
    Cloth
}

[System.Serializable]
public class ResourceBundle : IEnumerable<float>
{
    [SerializeField]
    private ResourceFloatDictionary _resourceAmountMapStore = ResourceFloatDictionary.New<ResourceFloatDictionary>();
    private Dictionary<Resource, float> _resourceAmountMap
    {
        get { return _resourceAmountMapStore.dictionary; }
    }
    public Dictionary<Resource, float>.KeyCollection Resources { get { return _resourceAmountMap.Keys; } }
    public Dictionary<Resource, float>.ValueCollection Values { get { return _resourceAmountMap.Values; } }



    public void Add(Resource resource, float amount)
    {
        if (_resourceAmountMap.ContainsKey(resource))
        {
            _resourceAmountMap[resource] += amount;
        }
        else
        {
            _resourceAmountMap[resource] = amount;
        }
    }

    public float this[Resource resource]
    {
        get
        {
            if (_resourceAmountMap.ContainsKey(resource))
            {
                return _resourceAmountMap[resource];
            }
            else
            {
                return 0f;
            }
        }

        set
        {
            _resourceAmountMap[resource] = value;
        }
    }

    public IEnumerator<float> GetEnumerator()
    {
        return _resourceAmountMap.Values.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return _resourceAmountMap.Values.GetEnumerator();
    }

    public override string ToString()
    {
        string output = "";

        foreach(Resource resource in _resourceAmountMap.Keys)
        {
            output += string.Format("{0}: {1}  ", resource, _resourceAmountMap[resource]);
            output += string.Format("{0}: {1}  ", resource, _resourceAmountMap[resource]);
        }

        return output;
    }


    public static ResourceBundle operator +(ResourceBundle a, ResourceBundle b)
    {
        return Combine(a, b);
    }

    public static ResourceBundle operator -(ResourceBundle a, ResourceBundle b)
    {
        return Combine(a, b * -1);
    }


    public static ResourceBundle operator *(ResourceBundle bundle, float i)
    {
        var resources = new List<Resource>(bundle.Resources);

        foreach(Resource resource in resources)
        {
            bundle[resource] *= i;
        }

        return bundle;
    }

    private static ResourceBundle Combine(ResourceBundle a, ResourceBundle b)
    {
        foreach (Resource resource in b.Resources)
        {
            a.Add(resource, b[resource]);
        }
        return a;
    }

    public bool FitsWithin(ResourceBundle b)
    {
        return FitsWithin(this, b);
    }

    public static bool FitsWithin(ResourceBundle a, ResourceBundle b)
    {
        foreach (Resource resource in a.Resources)
        {
            // If at least one resource is bigger in A, it won't fit inside B
            if (a[resource] > b[resource])
                return false;
        }
        return true;
    }
}
