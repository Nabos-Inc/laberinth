using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public void CloseDoor(){
        gameObject.SetActive(false);
    }
}
