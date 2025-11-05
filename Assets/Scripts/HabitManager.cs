using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class HabitManager : MonoBehaviour
{
    [SerializeField] private HabitSlot[] habitSlots;
    [SerializeField] private HabitSlot selectedHabitSlot;
    [SerializeField] private PlayerManager playerManager;
    
    [SerializeField] private TextMeshProUGUI habitName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private GameObject SellButton;

    [SerializeField] private GameObject RefundButton;

    [SerializeField] private EventPopup eventPopup;
    [SerializeField] private AudioSource learnHabitSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void deselectSlots()
    {
        for (int i = 0; i < habitSlots.Length; i++)
        {
            habitSlots[i].DeselectSlot();
        }
        this.selectedHabitSlot = null;
        habitName.text = "Habit";
        description.text = "";
        pointText.text = "Points";
        moneyText.text = "";
    }
    public void setSelectedHabitSlot(HabitSlot habitSlot)
    {
        this.selectedHabitSlot = habitSlot;
        habitName.text = habitSlot.habit.habitName;
        description.text = habitSlot.habit.description;
        if (habitSlot.hasFullySold)
        {
            pointText.text = habitSlot.habit.refundCost.ToString() + " Points to Unlearn"; 
            SellButton.SetActive(false);
            RefundButton.SetActive(true);
        }
        else
        {
            pointText.text = habitSlot.habit.pointCost.ToString() + " Points";
            if (habitSlot.habit.moneyCost <= 0)
            {
                moneyText.text = "";
            }
            else
            {
                moneyText.text = "$" + habitSlot.habit.moneyCost.ToString();
            }
            SellButton.SetActive(true);
            RefundButton.SetActive(false);
        }
    }

    public void updateDescription()
    {
        if (selectedHabitSlot.hasFullySold)
        {
            pointText.text = selectedHabitSlot.habit.refundCost.ToString() + " Points to Unlearn"; 
            SellButton.SetActive(false);
            RefundButton.SetActive(true);
        }
        else
        {
            pointText.text = (selectedHabitSlot.habit.pointCost + selectedHabitSlot.habit.pointLevelIncrease*selectedHabitSlot.habit.currentLevel).ToString() + " Points";   
            if (selectedHabitSlot.habit.moneyCost <= 0)
            {
                moneyText.text = "";
            }
            else
            {
                moneyText.text = "$" + selectedHabitSlot.habit.moneyCost.ToString();
            }
            SellButton.SetActive(true);
            RefundButton.SetActive(false);
        } 
    }

    public void learnHabit()
    {
        if (playerManager.points >= selectedHabitSlot.habit.pointCost + selectedHabitSlot.habit.pointLevelIncrease*selectedHabitSlot.habit.currentLevel && !selectedHabitSlot.hasFullySold && playerManager.money >= selectedHabitSlot.habit.moneyCost)
        {
            playerManager.points -= selectedHabitSlot.habit.pointCost + selectedHabitSlot.habit.pointLevelIncrease*selectedHabitSlot.habit.currentLevel;
            playerManager.money -= selectedHabitSlot.habit.moneyCost;
            playerManager.healthRate += selectedHabitSlot.habit.healthRate + selectedHabitSlot.habit.leveledHealthRate*selectedHabitSlot.habit.currentLevel;
            playerManager.painRate += selectedHabitSlot.habit.painRate + selectedHabitSlot.habit.leveledPainRate*selectedHabitSlot.habit.currentLevel;

            selectedHabitSlot.habit.currentLevel++;
            
            if (!selectedHabitSlot.hasbeenSold)
            {
                playerManager.health += selectedHabitSlot.habit.addHealth;
                playerManager.pain += selectedHabitSlot.habit.addPain;   
            }

            if (selectedHabitSlot.habit.currentLevel >= selectedHabitSlot.habit.levels+1)
            {
                selectedHabitSlot.hasFullySold = true;
            }
            
            selectedHabitSlot.hasbeenSold = true;
            
            learnHabitSound.Play();
            updateDescription();
            selectedHabitSlot.updateTierText();
        }
    }
    
    public void unlearnHabit()
    {
        if (playerManager.points >= selectedHabitSlot.habit.refundCost && selectedHabitSlot.hasFullySold)
        {
            playerManager.points -= selectedHabitSlot.habit.refundCost;
            playerManager.healthRate -= selectedHabitSlot.habit.healthRate;
            playerManager.painRate -= selectedHabitSlot.habit.painRate;
            if (selectedHabitSlot.habit.currentLevel >= 2)
            {
                selectedHabitSlot.habit.currentLevel--;
            }
            
            selectedHabitSlot.hasFullySold = false;
            updateDescription();
            selectedHabitSlot.updateTierText();
        }
    }

    public void mutate()
    {
        setSelectedHabitSlot(habitSlots[Random.Range(0, habitSlots.Length)]);
        if (selectedHabitSlot.hasFullySold)
        {
            setSelectedHabitSlot(habitSlots[Random.Range(0, habitSlots.Length)]);
        }

        if (!selectedHabitSlot.hasFullySold)
        {
            eventPopup.createEventPanel(selectedHabitSlot.habit.habitName + " has been mutated", "");
            learnHabit();
            deselectSlots();         
        }
    }

    private bool isAllSold()
    {
        foreach (HabitSlot habitSlot in habitSlots)
        {
            if (!habitSlot.hasbeenSold)
            {
                return false;
            }
        }

        return true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
