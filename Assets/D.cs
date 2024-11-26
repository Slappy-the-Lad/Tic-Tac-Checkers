using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class D : MonoBehaviour
{

    static string k, k2 = "";
    static Image C;
    static Color color = Color.blue;
    public GameObject P;
    public void Cclick(RectTransform t)
    {
        C = t.transform.Find("C").GetComponent<Image>();
        if (color == C.color)
        {
            string name = t.name;
            int i, j;
            i = Convert.ToInt32((name.Split('&'))[0]);
            j = Convert.ToInt32((name.Split('&'))[1]);
            int co = -1;
            if (C.color == Color.red) co = 1;
            try
            {
                if (!S.g[i + co, j - 1].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + co, j - 1].transform.Find("k").GetComponent<Image>().enabled = true;
                }
                else if (S.g[i + co, j - 1].transform.Find("C").GetComponent<Image>().color != C.color && !S.g [i + (co * 2), j - 2].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + (co * 2), j - 2].transform.Find("k").GetComponent<Image>().enabled = true;
                    k2 = (i + co) + " " + (j - 1);
                }
            }
            catch { }
            try 
            {
                if (!S.g[i + co, j + 1].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + co, j + 1].transform.Find("k").GetComponent<Image>().enabled = true;
                }
                else if (S.g[i + co, j + 1].transform.Find("C").GetComponent<Image>().color != C.color && !S.g[i + (co * 2), j + 2].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + (co * 2), j + 2].transform.Find("k").GetComponent<Image>().enabled = true;
                    k2 = (i + co) + " " + (j + 1);
                }
            }
            catch { }            
            k = i + " " + j;
        }
    }
}
