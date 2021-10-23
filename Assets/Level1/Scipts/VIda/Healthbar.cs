using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Vida playerVida;
    [SerializeField] private Image VidaTotal;
    [SerializeField] private Image VidaActual;

    private void Start()
    {
        VidaActual.fillAmount = playerVida.VidaActual / 10;
        VidaTotal.fillAmount = playerVida.maxHealth / 10;
    }

    private void Update()
    {

        VidaActual.fillAmount = playerVida.VidaActual / 10;
        VidaTotal.fillAmount = playerVida.maxHealth / 10;

    }

}
