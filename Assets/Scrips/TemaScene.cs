using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TemaScene : MonoBehaviour
{
    private soundCotroller soundController;
    private fade fade;

    public Text nomeTemaTxt;
    public Button btnJogar;


    [Header("Config Paginação")]
    public GameObject[] btnPaginacao;
    public GameObject[] painelTemas;
    private bool ativarBtnPaginacao;
    public int idPagina;

    // Start is called before the first frame update
    void Start()
    {
        soundController = FindObjectOfType(typeof(soundCotroller)) as soundCotroller;
        fade = FindObjectOfType(typeof(fade)) as fade;


        onOfButtonsPainel();

      
    }

    // Update is called once per frame
    void Update()
    {

    }


    void onOfButtonsPainel()
    {
        btnJogar.interactable = false;


        foreach(GameObject p in painelTemas)
        {
            p.SetActive(false);
        }

        painelTemas[0].SetActive(true);


        if (painelTemas.Length > 1)
        {
            ativarBtnPaginacao = true;
        }
        else
        {
            ativarBtnPaginacao = false;
        }

        foreach (GameObject b in btnPaginacao)
        {
            b.SetActive(ativarBtnPaginacao);
        }
    }


    public void Jogar()
    {
        soundController.playButton();
        soundController.audioMusic.clip = soundController.musicas[1];
        soundController.audioMusic.Play();

        int idCena = PlayerPrefs.GetInt("idTema");
        if (idCena != 0)
        {
            StartCoroutine("transicao", idCena.ToString());
        }
    }

    public void btnPagina(int i)
    {
        soundController.playButton();
        
        idPagina += i;
        if(idPagina < 0) { idPagina = painelTemas.Length - 1; }
        else if(idPagina >= painelTemas.Length){ idPagina = 0; }

        btnJogar.interactable = false;
        nomeTemaTxt.text = "Selecione um Tema!";
        nomeTemaTxt.color = Color.white;

        foreach (GameObject p in painelTemas)
        {
            p.SetActive(false);
        }

        painelTemas[idPagina].SetActive(true);

    }

    IEnumerator transicao(string nomeCena)
    {
        fade.fadeIn();
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        SceneManager.LoadScene(nomeCena);

    }

}
