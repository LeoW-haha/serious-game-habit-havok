using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject PatientMenuUI;
    [SerializeField] private GameObject PatientMenu;

    [SerializeField] private AudioSource buttonAudio;
    
    public void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void play()
    {
        buttonAudio.Play();
        SceneManager.LoadScene(1);
    }

    public void openPatientMenu()
    {
        buttonAudio.Play();
        TitleScreen.SetActive(false);
        PatientMenu.SetActive(true);
        PatientMenuUI.SetActive(true);
    }
    
    public void closePatientMenu()
    {
        buttonAudio.Play();
        TitleScreen.SetActive(true);
        PatientMenu.SetActive(false);
        PatientMenuUI.SetActive(false);
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
