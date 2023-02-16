using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaToText : MonoBehaviour
{
    [SerializeField] ManaBar manaBar;
    [SerializeField] TextMeshProUGUI manaUI;

    void Update()
    {
        manaUI.text = manaBar.currentMana.ToString();
    }
}
