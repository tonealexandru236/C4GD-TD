using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class On_die : MonoBehaviour
{
    public GameObject[] spawns;
    public int[] amt;

    private float progress;

    public void Update()
    {
        progress = GetComponent<SplineAnimate>().NormalizedTime;
    }

    private void OnDestroy()
    {
        //yield return new WaitForSeconds(0.1f);
        
        //StartCoroutine(
            MainButtons.instance.spawn_on_destroy(spawns, amt, progress, GetComponent<SplineAnimate>());
    }
}
