using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //deze functie zorgt er voor dat de scene voor de sartgame geload word.
    //script component zit aan de empty gameobject "MainMenu" gelinkt.
    //de functie word opgeroepen inde onclick event van de button "Start-Button".
    public void StartGame()
    {
        SceneManager.LoadScene("TestGameScene");
    }
    //deze functie zorgt er voor dat de scene voor de settings geload word.
    //script component zit aan de empty gameobject "MainMenu" gelinkt.
    //de functie word opgeroepen inde onclick event van de button "Settings-Button".
    public void OpenSettings()
    {
        SceneManager.LoadScene("TestSettingsScene");
    }
}
