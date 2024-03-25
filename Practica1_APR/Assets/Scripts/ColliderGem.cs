using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI; 

public class ColliderGem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            if(this.tag == "HealthGem")
            {
                GameManager.Instance.UpdateVida(1); 
            }
            if(this.tag == "StarGem")
            {
                GameManager.Instance.UpdateEstrellas(); 
            }
            Destroy(this.gameObject);
        }
    }
}
