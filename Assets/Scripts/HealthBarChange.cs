using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarChange : MonoBehaviour
{
    GameObject HealthBarCanvas;
    Image HealthBar;
    Enemy enemy;
    public float Current;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarCanvas = GameObject.FindGameObjectWithTag("EnemyHealthBar");
        HealthBar = gameObject.GetComponent<Image>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = enemy.HealthPercentage;
        if (enemy.HealthPercentage <= 0)
        {
            enemy = null;
            HealthBarCanvas.SetActive(false);
        }
    }
}
