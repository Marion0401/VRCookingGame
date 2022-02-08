using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public GameObject ingredientNonAssembleHolder;
    public bool isHolded = false;
    public bool wasHolded = false;
    public bool isAssembled = false;
    
    private LayerMask _ingredientLayer;
    private void Awake()
    {
        _ingredientLayer = LayerMask.NameToLayer("Ingredients");
    }
    void Update()
    {
        if (transform.parent == null)
        {
            isHolded = true;
            wasHolded = true;
        }
        else
        {
            isHolded = false;
            Holded();
        }
    }
    
    public void Holded()
    {
        //Si l'objet n'est plus maintenue mais que la frame d'avant il l'était et si il est un element assembler,
        if ( isAssembled == true & isHolded == false & wasHolded == true)
        {
            var transform1 = transform;
            transform1.parent = ingredientNonAssembleHolder.transform;
            transform1.gameObject.layer = _ingredientLayer;
            transform1.GetComponent<Rigidbody>().isKinematic = false;
            isAssembled = false;
            wasHolded = false;
        }

    }
    public void Assembled()
    {
        isAssembled = !isAssembled;
    }
}
