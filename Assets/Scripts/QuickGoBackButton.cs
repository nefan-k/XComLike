using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class QuickGoBackButton : MonoBehaviour
{

	 public void ReturnToLobby(){
 SceneManager.LoadScene("Menu");
}
  public void Test(){
 SceneManager.LoadScene("InterfaceIngame");
       }
  }
