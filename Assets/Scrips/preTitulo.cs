using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preTitulo : MonoBehaviour
{
    public int tempoEspera;
    private fade fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType(typeof(fade)) as fade;
        StartCoroutine("esperar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(tempoEspera);
        fade.fadeIn();
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        SceneManager.LoadScene("Titulo 1");
    }
}
