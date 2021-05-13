using UnityEngine;
using UnityEngine.UI;

public class TemaInfo : MonoBehaviour
{
    private soundCotroller soundController;
    private TemaScene temaScene;

    [Header("Configuração do Tema")]
    public int idTema;
    public string nomeTema;
    public Color corTema;
    public bool requerNotaMinima;
    public int notaMinimaNescessaria;

    [Header("Configuração das Estrelas")]
    public int notaMin1Estrela;
    public int notaMin2Estrela;




    [Header("Configuração do Botão")]
    public Text idTemaTxt;
    public GameObject[] estrela;

    public int notaFinal;
    private Button btnTema;


    // Start is called before the first frame update
    void Start()
    {
        soundController = FindObjectOfType(typeof(soundCotroller)) as soundCotroller;
        notaFinal = PlayerPrefs.GetInt("notaFinal_" + idTema.ToString());
        temaScene = FindObjectOfType(typeof(TemaScene)) as TemaScene;
        idTemaTxt.text = idTema.ToString();
        Estrelas();

        btnTema = GetComponent<Button>();

        verificarNotaMinima();
    }

    void verificarNotaMinima()
    {
        btnTema.interactable = false;
        if (requerNotaMinima == true)
        {
             int notaTemaAnterior = PlayerPrefs.GetInt("notaFinal_" + (idTema - 1).ToString());
             if(notaTemaAnterior >= notaMinimaNescessaria)
            {
                btnTema.interactable = true;

            }
        }
        else
        {
            btnTema.interactable = true;
        }
    }

    public void SelecionarTema()
    {
        soundController.playButton();
        temaScene.nomeTemaTxt.text = nomeTema;
        temaScene.nomeTemaTxt.color = corTema;

        PlayerPrefs.SetInt("idTema", idTema);
        PlayerPrefs.SetString("nomeTema", nomeTema);
        PlayerPrefs.SetInt("notaMin1Estrela", notaMin1Estrela);
        PlayerPrefs.SetInt("notaMin2Estrela", notaMin2Estrela);

        temaScene.btnJogar.interactable = true;
    }

    public void Estrelas()
    {
        foreach (GameObject e in estrela)
        {
            e.SetActive(false);
        }

        int nEstrelas = 0;

        if (notaFinal == 10) { nEstrelas = 3; }
        else if (notaFinal >= notaMin2Estrela) { nEstrelas = 2; }
        else if (notaFinal >= notaMin1Estrela) { nEstrelas = 1; }

        for (int i = 0; i < nEstrelas; i++)
        {
            estrela[i].SetActive(true);
        }

    }
}
