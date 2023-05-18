using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shootcountview : MonoBehaviour
{
    private TMP_Text textview;
   /* private int shootcount; // model이니 여기에 구현하지마*/

    private void Awake()
    {
        textview = GetComponent<TMP_Text>();

    }

    private void OnEnable()
    {
        GameManager.Data.OnShootCountChanged += ChangeText;
    }

    private void OnDisable()
    {
       GameManager.Data.OnShootCountChanged -= ChangeText;
    }


    private void ChangeText(int count)
    {
        textview.text = count.ToString();
    }

    //controller
    /*private void Addshoot(int count)
    {
        shootcount += count;
    }*/
}
