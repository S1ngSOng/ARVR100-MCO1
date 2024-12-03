using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Mainmenu : MonoBehaviourPunCallbacks
{
    public void playSinglePlayerGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
