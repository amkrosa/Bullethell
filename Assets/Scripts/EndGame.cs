using UnityEngine;

public class EndGame : Singleton<EndGame>
{
    public GameObject Win;
    public GameObject Lose;

    public void Close()
    {
        Application.Quit();
    }
}