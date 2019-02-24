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
public struct ResourceBundle
{
    public float Silver;
    public float Food;

    public ResourceBundle(Resource r, float amount) : this()
    {
        switch (r)
        {
            case Resource.Silver:
                Silver = amount;
                break;
            case Resource.Food:
                Food = amount;
                break;
        }
    }

    public ResourceBundle(ResourceBundle template)
    {
        Silver = template.Silver;
        Food = template.Food;
    }

    public bool FitsWithin(ResourceBundle b)
    {
        return (
            Silver <= b.Silver &&
            Food <= b.Food
            );
    }

    public ResourceBundle Add(ResourceBundle b)
    {
        var result = new ResourceBundle(this);
        result.Silver += b.Silver;
        result.Food += b.Food;
        return result;
    }

    public ResourceBundle Subtract(ResourceBundle b)
    {
        var result = new ResourceBundle(this);
        result.Silver -= b.Silver;
        result.Food -= b.Food;
        return result;
    }

    public ResourceBundle Multiply(float f)
    {
        var result = new ResourceBundle(this);
        result.Silver *= f;
        result.Food *= f;
        return result;
    }
}
