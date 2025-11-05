using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenHandler : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider painBar;
    [SerializeField] private Slider healthRateBar;
    [SerializeField] private Slider painRateBar;
    [SerializeField] private Image painRateBarImage;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject habitMenu;
    [SerializeField] private GameObject habitButton;

    [SerializeField] private AudioSource buttonClick;
    
    [SerializeField] private PlayerManager playerManager;

    public void openHabit()
    {
        buttonClick.Play();
        habitMenu.SetActive(true);
        habitButton.SetActive(false);
    }
    public void closeHabit()
    {
        buttonClick.Play();
        habitMenu.SetActive(false);
        habitButton.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerManager.health / playerManager.maxHealth;
        painBar.value = playerManager.pain / playerManager.maxPain;
        healthRateBar.value = playerManager.healthRate;
        if (playerManager.painRate < 0)
        {
            painRateBarImage.color = new Color(0, 94, 147);
            painRateBar.value = -playerManager.painRate;
        }
        else
        {
            painRateBarImage.color = new Color(6, 147, 0);
            painRateBar.value = playerManager.painRate;
        }
        pointText.text = playerManager.points + "/" + playerManager.turnPoints;
        moneyText.text = "Money: $" + playerManager.money;
    }
}
