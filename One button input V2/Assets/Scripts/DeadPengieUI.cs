using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadPengieUI : MonoBehaviour
{
    public static int deadPengies;
    [SerializeField]
    Text pengiesUICounter;
    Text fireRateUICounter;

    // Start is called before the first frame update
    void Start()
    {
        //deadPengies = PlayerPrefs.GetInt("Kills")*0;
        UpdateText();
    }

    // Update is called once per frame

    public void DeadPengies()
    {
        deadPengies += 1;
        Debug.Log(deadPengies + "Dead Pengies");

        //PlayerPrefs.SetInt("Kills", deadPengies);
        UpdateText();
    }
    void UpdateText()
    {
        pengiesUICounter.text = deadPengies + "Kills";
    }
    public void DeadTextUpdate()
    {
        deadPengies *= 0;
        Debug.Log("you lose");

    }
    void Update()
    {
        UpdateText();
    }
}

