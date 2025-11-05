using UnityEngine;

[CreateAssetMenu(fileName = "Habit", menuName = "Scriptable Objects/Habit")]
public class Habit : ScriptableObject
{
    public string habitName;
    [TextArea]
    public string description;
    public Sprite sprite;
    
    public float healthRate = 0;
    public float painRate = 0;
    
    public float leveledHealthRate = 0;
    public float leveledPainRate = 0;    
    
    public int pointCost = 0;
    public int moneyCost = 0;
    public int refundCost = 0;
    public int levels = 1;
    public int currentLevel = 1;
    public int pointLevelIncrease = 1;

    public float addHealth = 0;
    public float addPain = 0;
}
