using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class S : MonoBehaviour
{
    public static int n = 8;
    public GameObject D; 
    public static GameObject[,] g = new GameObject[n, n];
    void Start()
    {
        UnityEngine.Vector2 cs = transform.gameObject.GetComponent<RectTransform>().sizeDelta;
        UnityEngine.Vector2 size = D.GetComponent<RectTransform>().sizeDelta;
        cs.x /= 2;
        cs.y /= 2;
        float left = (cs.x - size.x) * -1;
        float top = (cs.y - size.y);
        Color[] colors = new Color[] { Color.white, Color.black }; 
        Image drt = D.GetComponent<Image>(), Ci = D.transform.Find("C").GetComponent<Image>();
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0) { colors[0] = Color.black; colors[1] = Color.white; }
            else { colors [0] = Color.white; colors[1] = Color.black; }
            for (int j = 0; j < n; j++)
            {
                drt.color = colors[(((j % 2) == 0) ? 0 : 1)];
                if (i == (n / 2) - 1 || i == (n / 2) || drt.color == Color.white) Ci.enabled = false;
                else Ci.enabled = true;
                if (i < (n / 2)) Ci.color = Color.red;
                else Ci.color = Color.blue;
                if (drt.color == Color.white) D.transform.Find("k2").GetComponent<Image>().enabled = false;
                else D.transform.Find("k2").GetComponent<Image>().enabled = true;

                g[i, j] = Instantiate(D);
                g[i, j].transform.SetParent(transform.Find("Panel1"));
                g[i, j].transform.localPosition = new UnityEngine.Vector3(left, top);
                g[i, j].transform.name = i + "&" + j;
                left += size.x;
            }
            left = (cs.x - size.x) * -1;
            top -= size.y;
        }
    }
}
