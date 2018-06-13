using UnityEngine;
using System.Collections;

public class temaInfo : MonoBehaviour {

    //controla as estrelas de cada fase...
    public int idTema;
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaFinal; //controla exibicao das estrelas em cada fase

    // Use this for initialization
    void Start () {

        estrela1.SetActive(false); //zera valor das estelas de cada fase
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString()); //carrega nota final
        
        if (notaFinal == 10)
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
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
