using UnityEngine;
using System.Collections;

public class ComandosBasicos : MonoBehaviour {

	public void carregaCena(string nomeCena)
    {
        Application.LoadLevel(nomeCena);
    }

    public void resetarPontuacao()
    {
        PlayerPrefs.DeleteAll();
    }
}
