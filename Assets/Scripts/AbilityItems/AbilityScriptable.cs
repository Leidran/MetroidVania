using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityScriptable", menuName = "ScriptableObjects/Abilities", order = 1)]
public class AbilityScriptable : ScriptableObject
{
    public MonoScript abilityScript;
    public Sprite abilitySprite;
}
