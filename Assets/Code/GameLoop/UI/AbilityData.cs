using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Ability", fileName = "Ability", order = 53)]
public class AbilityData : ScriptableObject
{
    public string Title;
    public string Description;
    public AbilityType Type;
}