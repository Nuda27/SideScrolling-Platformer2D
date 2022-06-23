using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currHealthBar.fillAmount = playerHealth.currHealth / 10;
    }
}
