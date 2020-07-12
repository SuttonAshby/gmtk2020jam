using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniUIManager : MonoBehaviour
{
    public static MiniUIManager Instance {get; private set; }
    public CanvasGroup playAgain;
    // Start is called before the first frame update
    void Awake(){
        if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
    }
    void Start()
    {
        // showMainMenu();
    }

    public void hidePlayAgain(){
        playAgain.alpha = 0;
        playAgain.interactable = false;
        playAgain.blocksRaycasts = false;
    }
    public void showPlayAgain(){
        playAgain.alpha = 1;
        playAgain.interactable = true;
        playAgain.blocksRaycasts = true;
    }

    // public void showMainMenu(){
    //     mainMenu.alpha = 1;
    //     mainMenu.interactable = true;
    //     mainMenu.blocksRaycasts = true;
    // }

    // public void hideMainMenu(){
    //     mainMenu.alpha = 0;
    //     mainMenu.interactable = false;
    //     mainMenu.blocksRaycasts = false;
    // }

    // public void Play(){
    //     hideMainMenu();
    //     GameManager.Instance.isPlaying = true;
    // }


}
