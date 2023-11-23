using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public AudioClip coinCollectSound; // Asigna el archivo de sonido en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCollectibleManager playerCollectibleManager = other.GetComponent<PlayerCollectibleManager>();
            if (playerCollectibleManager != null)
            {
                playerCollectibleManager.CollectCoin();
                AudioSource.PlayClipAtPoint(coinCollectSound, transform.position); // Reproduce el sonido en la posición de la moneda
                Destroy(gameObject);
            }
        }
    }
}
