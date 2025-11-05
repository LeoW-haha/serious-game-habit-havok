using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Sprite[] TutorialScreen;
    private int CurrentIndex;
    [SerializeField] private Sprite empty;
    [SerializeField] private GameObject TutorialUI;
    [SerializeField] private SpriteRenderer TutorialSprite;
    [SerializeField] private GameObject TitleScreen;
    
    [SerializeField] private AudioSource buttonAudio;

    public void close()
    {
        buttonAudio.Play();
        TutorialUI.SetActive(false);
        TitleScreen.SetActive(true);
        TutorialSprite.sprite = empty;
    }

    public void open()
    {
        buttonAudio.Play();
        TutorialUI.SetActive(true);
        TitleScreen.SetActive(false);
        TutorialSprite.sprite = TutorialScreen[0];
        CurrentIndex = 0;
    }

    public void right()
    {
        buttonAudio.Play();
        CurrentIndex++;
        if (CurrentIndex > TutorialScreen.Length - 1)
        {
            CurrentIndex = 0;
        }
        TutorialSprite.sprite = TutorialScreen[CurrentIndex];
    }
    
    public void left()
    {
        buttonAudio.Play();
        CurrentIndex--;
        if (CurrentIndex < 0)
        {
            CurrentIndex = TutorialScreen.Length - 1;
        }
        TutorialSprite.sprite = TutorialScreen[CurrentIndex];
    }
                
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
