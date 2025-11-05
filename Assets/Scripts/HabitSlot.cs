using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HabitSlot : MonoBehaviour, IPointerClickHandler
{
    public Habit baseHabit;
    public Habit habit;
    
    private bool isSelected = false;
    public bool hasFullySold = false;
    public bool hasbeenSold = false;

    [SerializeField] private HabitManager habitManager;
    [SerializeField] private GameObject SelectedShader;
    [SerializeField] private Image Sprite;
    [SerializeField] private TextMeshProUGUI tierText;
    [SerializeField] private AudioSource buttonClick;
    
    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            SelectSlot();
            buttonClick.Play();
        }
        if (eventData.button == PointerEventData.InputButton.Right) {
            habitManager.deselectSlots();
            buttonClick.Play();
        }
    }

    public void SelectSlot()
    {
        habitManager.deselectSlots();
        isSelected = true;
        SelectedShader.SetActive(true);
        habitManager.setSelectedHabitSlot(this);
    }
    
    public void DeselectSlot()
    {
        isSelected = false;
        SelectedShader.SetActive(false);
    }

    public void updateTierText()
    {
        tierText.text = habit.currentLevel.ToString();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        habit = Instantiate(baseHabit);
        
        Sprite.sprite = habit.sprite;
        if (habit.levels <= 1)
        {
            tierText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
