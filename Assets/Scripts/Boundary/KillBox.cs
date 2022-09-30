using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour{

    void OnTriggerExit2D(Collider2D other){
        if(other.transform.parent == null)
            return;

        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
