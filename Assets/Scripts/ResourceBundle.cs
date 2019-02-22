using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Resource
{
    Gold,
    Food,
    Culture,
    Wood,
    Stone,
    Wool,
    Cloth
}

[System.Serializable]
public class ResourceBundle : IEnumerable<int>
{
    [SerializeField]
    private ResourceIntDictionary _resourceAmountMapStore = ResourceIntDictionary.New<ResourceIntDictionary>();
    private Dictionary<Resource, int> _resourceAmountMap
    {
        get { return _resourceAmountMapStore.dictionary; }
    }
    public Dictionary<Resource, int>.KeyCollection Resources { get { return _resourceAmountMap.Keys; } }
    public Dictionary<Resource, int>.ValueCollection Values { get { return _resourceAmountMap.Values; } }

    public void Add(Resource resource, int amount)
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

    public int this[Resource resource]
    {
        get
        {
            if (_resourceAmountMap.ContainsKey(resource))
            {
                return _resourceAmountMap[resource];
            }
            else
            {
                return 0;
            }
        }

        set
        {
            _resourceAmountMap[resource] = value;
        }
    }

    public IEnumerator<int> GetEnumerator()
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


    public static ResourceBundle operator *(ResourceBundle bundle, int i)
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
}
