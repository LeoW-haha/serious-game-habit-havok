using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int turnNo = 0;
    public int maxTurn = 50;
    [SerializeField] private TextMeshProUGUI turnText;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private EventManager eventManager;

    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private GameObject continueButton;
    
    [SerializeField] private GameObject habitButton;
    [SerializeField] private GameObject nextTurnButton;

    [SerializeField] private AudioSource nextTurnSnd;
    [SerializeField] private AudioSource winSnd;
    [SerializeField] private AudioSource loseSnd;

    private bool newGamePlus = false;
    
    public void advanceTurn()
    {
        turnNo++;
        turnText.text = "Turn " + turnNo + "/" + maxTurn;
        playerManager.advanceTurn();
        eventManager.triggerEvent();
        nextTurnSnd.Play();
        if (playerManager.health <= 0)
        {
            endGame(false);
        }

        if (playerManager.health > 0 && turnNo >= maxTurn && !newGamePlus)
        {
            endGame(true);
        }
    }

    public void endGame(bool boolean)
    {
        endScreen.SetActive(true);
        pause();
        if (boolean)
        {
            winSnd.Play();
            continueButton.SetActive(true);
            endText.text = "You Win";
        }
        else
        {
            loseSnd.Play();
            continueButton.SetActive(false);
            endText.text = "You Lose";
        }
    }

    public void continueGame()
    {
        endScreen.SetActive(false);
        unPause();
        newGamePlus = true;
        advanceTurn();
    }

    public void pause()
    {
        habitButton.SetActive(false);
        nextTurnButton.SetActive(false);
    }
    
    public void unPause()
    {
        habitButton.SetActive(true);
        nextTurnButton.SetActive(true);
    }

    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turnText.text = "Turn " + turnNo + "/" + maxTurn;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
