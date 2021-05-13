using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    private soundCotroller soundController;
    public GameObject painel1, painel2;
    public Toggle onOffMusica, onOffEfeitos;
    public Slider volumeM, volumeE;


    private void Start()
    {
        soundController = FindObjectOfType(typeof(soundCotroller)) as soundCotroller;
        carregarPreferencias();
        painel1.SetActive(true);
        painel2.SetActive(false);
    }

    public void configuracoes(bool onOf)
    {
        soundController.playButton();
        painel1.SetActive(!onOf);
        painel2.SetActive(onOf);
    }

    public void zerarProgresso()
    {
        int onOffM = PlayerPrefs.GetInt("onOffMusica");
        int onOffE = PlayerPrefs.GetInt("onOffEfeitos");
        float volumeMusica = PlayerPrefs.GetFloat("volumeMusica");
        float volumeEefeito = PlayerPrefs.GetFloat("volumeEfeitos");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("valoresDefault", 1);
        PlayerPrefs.SetInt("onOffMusica", onOffM);
        PlayerPrefs.SetInt("onOffEfeitos", onOffE);
        PlayerPrefs.SetFloat("volumeMusica", volumeMusica);
        PlayerPrefs.SetFloat("volumeEfeitos", volumeEefeito);

    }
    // Update is called once per frame

    public void mutarMusica()
    {
        soundController.audioMusic.mute = !onOffMusica.isOn;
        if (onOffMusica.isOn == true)
        {
            PlayerPrefs.SetInt("onOffMusica", 1);
        }
        else
        {
            PlayerPrefs.SetInt("onOffMusica", 0);
        }

    }

    public void mutarEfeitos()
    {
        soundController.audioFX.mute = !onOffEfeitos.isOn;
        if (onOffEfeitos.isOn == true)
        {
            PlayerPrefs.SetInt("onOffEfeitos", 1);
        }
        else
        {
            PlayerPrefs.SetInt("onOffEfeitos", 0);
        }
    }

    public void volumeMusica()
    {
        soundController.audioMusic.volume = volumeM.value;
        PlayerPrefs.SetFloat("volumeMusica", volumeM.value);
    }


    public void volumeEfeitos()
    {
        soundController.audioFX.volume = volumeE.value;
        PlayerPrefs.SetFloat("volumeEfeitos", volumeE.value);
    }

    void carregarPreferencias()
    {

        //carrega os valores de configuracao de sons e musioca
        int onOffM = PlayerPrefs.GetInt("onOffMusica");
        int onOffE = PlayerPrefs.GetInt("onOffEfeitos");
        float volumeMusica = PlayerPrefs.GetFloat("volumeMusica");
        float volumeEefeito = PlayerPrefs.GetFloat("volumeEfeitos");

        bool tocarMusica = false;
        bool tocarEfeitos = false;

        if (onOffM == 1) { tocarMusica = true; }
        if (onOffE == 1) { tocarEfeitos = true; }

        onOffMusica.isOn = tocarMusica;
        onOffEfeitos.isOn = tocarEfeitos;

        volumeM.value = volumeMusica;
        volumeE.value = volumeEefeito;

    }


}


