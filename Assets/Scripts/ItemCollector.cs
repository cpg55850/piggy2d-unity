using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] AudioSource nom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.1f, gameObject.transform.localScale.y * 1.1f, gameObject.transform.localScale.z * 1.1f);
            nom.Play();
        }
    }
}
