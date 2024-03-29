using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //deze functie zorgt er voor dat de scene voor de sartgame geload word.
    //script component zit aan de empty gameobject "MainMenu" gelinkt.
    //de functie word opgeroepen inde onclick event van de button "Start-Button".
    public void StartGame()
    {
        SceneManager.LoadScene("Parallax");
    }
    //deze functie zorgt er voor dat de scene voor de settings geload word.
    //script component zit aan de empty gameobject "MainMenu" gelinkt.
    //de functie word opgeroepen inde onclick event van de button "Settings-Button".
    public void OpenSettings()
    {
        SceneManager.LoadScene("TestSettingsScene");
    }

    public void CloseSettings()
    {
        SceneManager.LoadScene("TestMainMenuUI");
    }
    //deze functie zorgt er voor dat de scene voor de HowToPlay geload word.
    //script component zit aan de empty gameobject "MainMenu" gelinkt.
    //de functie word opgeroepen inde onclick event van de button "HowToPlay - Button".
    public void OpenHowToPlay()
    {
        SceneManager.LoadScene("TestHowToPlayScene");
    }

    public void CloseHowToPlay()
    {
        SceneManager.LoadScene("TestMainMenuUI");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}