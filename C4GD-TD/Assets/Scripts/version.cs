using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class version : MonoBehaviour
{
    public TMP_Text versions;
    void Start()
    {
        versions.SetText("V" + Application.version);
    }
}
