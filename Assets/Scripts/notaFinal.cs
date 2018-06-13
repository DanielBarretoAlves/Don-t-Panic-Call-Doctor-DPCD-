using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class notaFinal : MonoBehaviour {

    private int idTema;
    public Text txtNota;
    public Text txtInfoTema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaF; //notafinal
    private int acertos;

    // Use this for initialization
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema"); //carrega tema

        estrela1.SetActive(false); //desliga as estrelas
        estrela2.SetActive(false);
        estrela3.SetActive(false);
                
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString()); //carrega nota final
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString()); //carrega acertos

        txtNota.text = notaF.ToString();
        txtInfoTema.text = "Acertos:" + acertos.ToString();

        if (notaF == 10)
        {
            estrela1.SetActive(true); //liga as 3 estrelas
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaF >= 7)
        {
            estrela1.SetActive(true); //liga 2 estrelas
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaF >= 5)
        {
            estrela1.SetActive(true); //liga 1 estrela
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }
    }
    
    public void jogarNovamente()
    {
        Application.LoadLevel("Tema" + idTema.ToString());
    }	
}
