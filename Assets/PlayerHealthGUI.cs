using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthGUI : MonoBehaviour
{
    Player player;
    Text playerHealthText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerHealthText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "HP: " + player.Health;
    }
}
