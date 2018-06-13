using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tema_Jogo : MonoBehaviour {

    public Button btn_Play;
    public Text txt_nome_tema;

    public GameObject Info_Level;
    public Text txt_info_tema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    public string[] nomeTema;
    public int numeroQuestoes;

    private int idTema;

    // Use this for initialization
    void Start () {

        idTema = 0;
        txt_nome_tema.text = nomeTema[idTema];
        txt_info_tema.text = ""; //zera valor dos pontos, caso nao tenha jogado

        Info_Level.SetActive(false);    //nome do tema entra como 'Selecione um tema'
        estrela1.SetActive(false);  //seta valor da estrela para desligado
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        btn_Play.interactable = false; //desativa botao play sem tema selecionado
	}

    public void selecioneTema(int i)
    {
        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
        txt_nome_tema.text = nomeTema[i];

            int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString()); //carrega nota final
            int qtdAcertos = PlayerPrefs.GetInt("acertos" + idTema.ToString());

        estrela1.SetActive(false);  //seta valor da estrela para desligado
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        if (notaFinal == 10) //ativa as estrelas
        {
            estrela1.SetActive(true); //liga as 3 estrelas
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true); //liga 2 estrelas
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 5)
        {
            estrela1.SetActive(true); //liga 1 estrela
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }


        txt_info_tema.text = "Questões Acertadas: " + qtdAcertos.ToString() + " de " +numeroQuestoes.ToString(); //exibe acerto de questoes do usuario
        Info_Level.SetActive(true);
        btn_Play.interactable = true;
    }
	
    public void jogar()
    {
        Application.LoadLevel("Tema" + idTema.ToString());
    }
}
