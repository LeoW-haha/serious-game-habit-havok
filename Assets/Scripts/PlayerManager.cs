using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float pain = 0;
    public float maxPain = 100;
    public float mutationRate = 0;
    public int money;
    public int salary;
    
    public int turnPoints;
    public int points;

    public float healthRate;
    public float painRate;

    [SerializeField] private HabitManager habitManager;

    public void advanceTurn()
    {
        turnPoints -= (int)pain / 10;
        turnPoints += (int)healthRate / 10;
        
        points = turnPoints;
        healthRate -= painRate * 0.1f;
        
        float newhealth = health * (1 + healthRate);
        if ((newhealth - health) < 0 && (newhealth - health) > -0.1)
        {
            health -= 0.1f;
        }
        else
        {
            health = newhealth;
        }
        float newpain = pain * (1 + painRate);
        if ((newpain - pain) < 0 && (newpain - pain) > -0.1)
        {
            pain -= 0.1f;
        }
        else
        {
            pain = newpain;
        }

        money += (int)(salary * 1 + healthRate* - pain*0.1);

        if (habitManager && Random.Range(0.0f, 100.0f) <= mutationRate)
        {
            habitManager.mutate();
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = turnPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 100)
        {
            health = 100;
        }
        if (pain > 100)
        {
            pain = 100;
        }
        if (health < 0)
        {
            health = 0;
        }
        if (pain < 0)
        {
            pain = 0;
        }

        if (points < 0)
        {
            points = 0;
        }
        
        if (turnPoints < 0)
        {
            turnPoints = 0;
        }
    }
}
