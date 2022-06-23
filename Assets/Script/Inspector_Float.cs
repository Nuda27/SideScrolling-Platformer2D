/*
 * Desc     : Membuat fungsi untuk menyimpan data dan menyiapkan kondisinya
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inspector_Float : MonoBehaviour
{
    [Header("Main Settings")]
    public float DataFloat;
    //public Text TextFloat;
    //public GameObject Player;

    [Header("Condition")]
    public float ConditionFloat;
    public UnityEvent ConditionEvent;
    bool isExecuted = false;

    // fungsi menambah nilai variabel
    public void AddValue(float aValue)
    {
        DataFloat += aValue;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //menampilkan nilai float ke text ui
        //TextFloat.text = DataFloat.ToString();

        //memeriksa jika event belum pernah dieksekusi
        if (!isExecuted)
        {
            //cek nilai kondisi dengan nilai variabel
            if (ConditionFloat == DataFloat)
            {
                //Time.timeScale = 0;
                //Player.SetActive(false);
                ConditionEvent.Invoke();
            }
        }
    }
}
