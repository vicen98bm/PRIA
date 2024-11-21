using System.Collections;
using System.Collections.Generic;
using TMPro;    
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class MainMenuLauncher : MonoBehaviourPunCallbacks 
{
    public TMP_InputField usernameInput;
    public TMP_Text buttonText;

    public void OnClickConnect()
    {
        if (usernameInput.text.Length > 5)
        {
            PhotonNetwork.NickName = usernameInput.text;
            PlayerPrefs.SetString("PlayerName", usernameInput.text);
            buttonText.text = "Conectando...";
            PhotonNetwork.ConnectUsingSettings();
        }
        else 
        {
            Debug.Log("El nombre debe tener más de 5 caracteres"); 
        }
    }
          public override void OnConnectedToMaster()
       {
        Debug.Log("Nos hemos conectado al master");
        SceneManager.LoadScene("SceneMultiplayer"); 
       }
   
}
