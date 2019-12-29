using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarChange : MonoBehaviour
{
    Image HealthBar;
    public float Current;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = gameObject.GetComponentInParent<Enemy>().HealthPercentage;
    }
}
