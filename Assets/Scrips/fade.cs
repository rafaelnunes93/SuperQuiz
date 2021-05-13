using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public GameObject   painelTransicao;
    public Image        fume;

    public Color[] corTransicao;
    public float step; //determinar a velocidade da transição


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void fadeIn() { StartCoroutine("fadeI"); }


    public void fadeOut() { StartCoroutine("fadeO"); }


    IEnumerator fadeI() {

        painelTransicao.SetActive(true);

        for(float i = 0; i <= 1; i += step)
        {
            fume.color = Color.Lerp(corTransicao[0], corTransicao[1], i);
            yield return new WaitForEndOfFrame();
        }

    }

    IEnumerator fadeO() {

        for (float i = 0; i <= 1; i += step)
        {
            fume.color = Color.Lerp(corTransicao[1], corTransicao[0], i);
            yield return new WaitForEndOfFrame();
        }

        painelTransicao.SetActive(false);
    }

}
