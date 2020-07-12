using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public CanvasGroup mainMenu;
    public CanvasGroup credits;
    public CanvasGroup howTo;
    public static UIManager Instance {get; private set; }

    void Awake(){
        if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
    }
    // Start is called before the first frame update
    void Start()
    {
        goToMainMenu();
    }

    public void goToMainMenu(){
        Debug.Log("GO TO MAIN MENU FUNC");
        mainMenu.alpha = 1;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true;

        credits.alpha = 0;
        credits.interactable = false;
        credits.blocksRaycasts = false;

        howTo.alpha = 0;
        howTo.interactable = false;
        howTo.blocksRaycasts = false;
    }

    public void goToCredits(){
        mainMenu.alpha = 0;
        mainMenu.interactable = false;
        mainMenu.blocksRaycasts = false;

        credits.alpha = 1;
        credits.interactable = true;
        credits.blocksRaycasts = true;

        howTo.alpha = 0;
        howTo.interactable = false;
        howTo.blocksRaycasts = false;
    }

    public void goTohowTo(){
        mainMenu.alpha = 0;
        mainMenu.interactable = false;
        mainMenu.blocksRaycasts = false;

        credits.alpha = 0;
        credits.interactable = false;
        credits.blocksRaycasts = false;

        howTo.alpha = 1;
        howTo.interactable = true;
        howTo.blocksRaycasts = true;
    }

    public void Play(){
        mainMenu.alpha = 0;
        mainMenu.interactable = false;
        mainMenu.blocksRaycasts = false;

        credits.alpha = 0;
        credits.interactable = false;
        credits.blocksRaycasts = false;

        howTo.alpha = 0;
        howTo.interactable = false;
        howTo.blocksRaycasts = false;

        GameManager.Instance.isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
