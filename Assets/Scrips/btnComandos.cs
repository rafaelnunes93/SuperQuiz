using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnComandos : MonoBehaviour
{
    private soundCotroller soundController;
    public GameObject painel1,painel2;
    private fade fade;

   
    private void Start()
    {
        fade = FindObjectOfType(typeof(fade)) as fade;

        soundController = FindObjectOfType(typeof(soundCotroller)) as soundCotroller;
    }

    // Vai para uma nova cena
    public void irParaCena(string nomeCena)
    {
        soundController.playButton();

        if (SceneManager.GetActiveScene().name != "Titulo 1" && SceneManager.GetActiveScene().name != "Temas")
        {
            soundController.audioMusic.clip = soundController.musicas[0];
            soundController.audioMusic.Play();
        }
        StartCoroutine("transicao", nomeCena);
    }


    //Fecha o Aplicativo 
    public void sair()
    {
        Application.Quit();
    }

    public void jogarNovamente()
    {
        soundController.playButton();
        int idCena = PlayerPrefs.GetInt("idTema");
        if (idCena != 0)
        {
            SceneManager.LoadScene(idCena.ToString());
        }
    }   

    IEnumerator transicao(string nomeCena)
    {
        fade.fadeIn();
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        SceneManager.LoadScene(nomeCena);

    }

}
 