using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    [SerializeField] AbilityScriptable abilityData;
    
    SpriteRenderer renderSprite;
    MonoScript scriptAbility;

    private void Start()
    {
        renderSprite = GetComponent<SpriteRenderer>();
        renderSprite.sprite = abilityData.abilitySprite;
        scriptAbility = abilityData.abilityScript;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BetterPlayerController>() && !collision.gameObject.GetComponent(scriptAbility.GetClass()))
        {
            collision.gameObject.AddComponent(scriptAbility.GetClass());
            Destroy(gameObject);
        }
    }
}
