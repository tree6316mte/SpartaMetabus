

using System;
using System.Collections.Generic;
using UnityEngine;

public enum UnitSpriteSlot
{
    EYE_LEFT,
    EYE_RIGHT,
    HAIR,
    FACE_HAIR,
    CLOTH_BODY,
    CLOTH_LEFT,
    CLOTH_RIGHT,
    PANT_LEFT,
    PANT_RIGHT,
    HELMET,
    ARMOR_BODY,
    ARMOR_LEFT,
    ARMOR_RIGHT,
    WEAPON_LEFT,
    WEAPON_RIGHT,
    SHIELD_LEFT,
    SHIELD_RIGHT,
    BACK,
}

[Serializable]
public class UnitSpriteSource
{
    public UnitSpriteSlot slot;
    public Sprite sprite;
}

public class UnitSpriteElement : MonoBehaviour
{
    [SerializeField]
    public List<UnitSpriteSource> sources;
}