using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandFog : MonoBehaviour
{
    public float timeToDie = 3;

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(_Destroy());
        }
        
    }
    IEnumerator _Destroy()
    {
        yield return new WaitForSeconds (timeToDie);
        gameObject.SetActive (false);
    }
}
