using TMPro;
using UnityEngine;

public class EventPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EventName;

    [SerializeField] private TextMeshProUGUI EventDescription;

    [SerializeField] private GameObject eventPanel;

    [SerializeField] private GameManager gameManager;
    
    public void createEventPanel(string name, string description) {
        eventPanel.SetActive(true);
        gameManager.pause();
        EventName.text = name;
        EventDescription.text = description;
    }

    public void close()
    {
        eventPanel.SetActive(false);
        gameManager.unPause();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
