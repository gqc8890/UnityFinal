using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocValue : MonoBehaviour
{
    [SerializeField]
    string m_key;

    void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        if(text && m_key != "")
        {
            text.text = LocalizationManager.Instance.GetLocalizedValue(m_key);
        }
    }
}
