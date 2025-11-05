using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Scriptable Objects/Event")]

public class Event : ScriptableObject
{
    public string habitName;
    [TextArea]
    public string description;
    
    public float healthRate = 0;
    public float painRate = 0;
    public int addSalary = 0;
    
    public float addHealth = 0;
    public float addPain = 0;
    public int addMoney = 0;

    public float chance = 0;

    public bool repeatable = false;
    [SerializeField] private bool hasOccured = false;

    public int triggerEventChance(PlayerManager playerManager, float random)
    {
        if (!repeatable && hasOccured)
        {
            return 0;
        }

        if (random > chance)
        {
            return 1;
        }
        
        playerManager.healthRate += healthRate;
        playerManager.painRate += painRate;
        playerManager.health += addHealth;
        playerManager.pain += addPain;
        playerManager.money += addMoney;
        playerManager.salary += addSalary;
        hasOccured = true;

        return 2;
    }

    public bool getHasOccured()
    {
        return hasOccured;
    }

    public void setHasOccured(bool value)
    {
        hasOccured = value;
    }
}
