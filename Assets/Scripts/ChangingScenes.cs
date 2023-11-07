using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangingScenes : MonoBehaviour

{

public GameObject Menu;
public GameObject Setting;
public GameObject Stats;
public GameObject BeforeStart;
public GameObject BeforeInGame;
public GameObject InGameUI;
public GameObject InGameSettings;
public GameObject EscMenu;
public GameObject EscSystem;
public GameObject DW1;
public GameObject DW2;
	
            public void InGameUIToBeforeInGame(){
     InGameUI.SetActive(false);
     BeforeInGame.SetActive(true);
       }
        public void BeforeInGameToInGameUI(){
     InGameUI.SetActive(true);
     BeforeInGame.SetActive(false);
     }
    
	   public void Options(){
     Setting.SetActive(true);
     Menu.SetActive(false);
     DW1.SetActive(false);
     DW2.SetActive(false);
	}

        public void StartToBeforeStart(){
     BeforeStart.SetActive(true);
     Menu.SetActive(false);
     DW1.SetActive(false);
     DW2.SetActive(false);
    }
        public void BeforeStartToStart(){
     BeforeStart.SetActive(false);
     Menu.SetActive(true);
     DW1.SetActive(true);
     DW2.SetActive(true);
    }

	   public void exitgame(){
     Application.Quit();


	}
		public void ToLobby(){
     SceneManager.LoadScene("Menu");
	}
        public void OptionToLobby(){
     Setting.SetActive(false);
     Menu.SetActive(true);
     DW1.SetActive(true);
     DW2.SetActive(true);
    }

        public void StatsToLobby(){
     Stats.SetActive(false);
     Menu.SetActive(true);
     DW1.SetActive(true);
     DW2.SetActive(true);
    }
        public void ToStats(){
     Stats.SetActive(true);
     Menu.SetActive(false);
     DW1.SetActive(false);
     DW2.SetActive(false);
}

    public void InGameSettingsToMenu(){
     InGameSettings.SetActive(false);
     EscMenu.SetActive(true);
     EscSystem.SetActive(true);
       }
           public void IngameMenuToInGameSettings(){
     InGameSettings.SetActive(true);
     EscMenu.SetActive(false);
     EscSystem.SetActive(false);
       }
}

    


    


    

