using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpriteHandler : MonoBehaviour
{
    [SerializeField] SpriteRenderer eye_left;
    [SerializeField] SpriteRenderer eye_right;
    [SerializeField] SpriteRenderer hair;
    [SerializeField] SpriteRenderer face_hair;
    [SerializeField] SpriteRenderer cloth_body;
    [SerializeField] SpriteRenderer cloth_left;
    [SerializeField] SpriteRenderer cloth_right;
    [SerializeField] SpriteRenderer pant_left;
    [SerializeField] SpriteRenderer pant_right;
    [SerializeField] SpriteRenderer helmet;
    [SerializeField] SpriteRenderer armor_body;
    [SerializeField] SpriteRenderer armor_left;
    [SerializeField] SpriteRenderer armor_right;
    [SerializeField] SpriteRenderer weapon_left;
    [SerializeField] SpriteRenderer weapon_right;
    [SerializeField] SpriteRenderer shield_left;
    [SerializeField] SpriteRenderer shield_right;
    [SerializeField] SpriteRenderer back;

    public void SetSprite(UnitSpriteElement spriteElement)
    {
        foreach (var element in spriteElement.sources)
        {
            SetSprite(element.slot, element.sprite);
        }
    }

    public void SetSprite(UnitSpriteSlot slot, Sprite sprite)
    {
        switch (slot)
        {
            case UnitSpriteSlot.EYE_LEFT:
                eye_left.sprite = sprite;
                break;
            case UnitSpriteSlot.EYE_RIGHT:
                eye_right.sprite = sprite;
                break;
            case UnitSpriteSlot.HAIR:
                hair.sprite = sprite;
                break;
            case UnitSpriteSlot.FACE_HAIR:
                face_hair.sprite = sprite;
                break;
            case UnitSpriteSlot.CLOTH_BODY:
                cloth_body.sprite = sprite;
                break;
            case UnitSpriteSlot.CLOTH_LEFT:
                cloth_left.sprite = sprite;
                break;
            case UnitSpriteSlot.CLOTH_RIGHT:
                cloth_right.sprite = sprite;
                break;
            case UnitSpriteSlot.PANT_LEFT:
                pant_left.sprite = sprite;
                break;
            case UnitSpriteSlot.PANT_RIGHT:
                pant_right.sprite = sprite;
                break;
            case UnitSpriteSlot.HELMET:
                helmet.sprite = sprite;
                break;
            case UnitSpriteSlot.ARMOR_BODY:
                armor_body.sprite = sprite;
                break;
            case UnitSpriteSlot.ARMOR_LEFT:
                armor_left.sprite = sprite;
                break;
            case UnitSpriteSlot.ARMOR_RIGHT:
                armor_right.sprite = sprite;
                break;
            case UnitSpriteSlot.WEAPON_LEFT:
                weapon_left.sprite = sprite;
                break;
            case UnitSpriteSlot.WEAPON_RIGHT:
                weapon_right.sprite = sprite;
                break;
            case UnitSpriteSlot.SHIELD_LEFT:
                shield_left.sprite = sprite;
                break;
            case UnitSpriteSlot.SHIELD_RIGHT:
                shield_right.sprite = sprite;
                break;
            case UnitSpriteSlot.BACK:
                back.sprite = sprite;
                break;
        }
    }
}