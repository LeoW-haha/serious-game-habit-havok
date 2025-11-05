using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private Event[] eventsHolder;
    private List<Event> events = new List<Event>();
    [SerializeField] private EventPopup eventPopup;
    [SerializeField] private PlayerManager playerManager;

    [SerializeField] private float eventChance;
    [SerializeField] private AudioSource eventSound;

    public void triggerEvent()
    {
        if (Random.Range(0.0f, 100.0f) <= eventChance)
        {
            int seed = Random.Range(0, events.Count);
            int i = events[seed].triggerEventChance(playerManager, Random.Range(0.0f, 100.0f));

            if (i == 2)
            {
                eventSound.Play();
                eventPopup.createEventPanel(events[seed].habitName, events[seed].description);
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddItem(Event _orginalScriptableItem)
    {
        // Creating copy of the item
        Event _coppyScriptableItem = Instantiate(_orginalScriptableItem);

        // Add copy of the item to the list
        events.Add(_coppyScriptableItem );
    }

    public void RemoveItem(Event _itemToRemove)
    {
        if (events.Contains(_itemToRemove))
        {
            // Remove the item from the list
            events.Remove(_itemToRemove);

            // Destroy the copy to free up memory
            Destroy(_itemToRemove);
        }
    }

    private void OnDestroy()
    {
        // Cleanup all items when this manager is destroyed
        foreach (var item in events)
        {
            Destroy(item);
        }

        events.Clear();
    }
    void Start()
    {
        foreach (Event a in eventsHolder)
        {
            AddItem(a);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
