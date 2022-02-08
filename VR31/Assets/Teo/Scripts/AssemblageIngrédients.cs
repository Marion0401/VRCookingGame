using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblageIngrédients : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _Assiette;
    [SerializeField] private GameObject _IngredientHolder;
    private List<GameObject> _ListIngredients = new List<GameObject>();
    private float totalLocalHauteurY;
    private float ancienneHauteurY;
    private LayerMask _ingredientLayer;
    private LayerMask _assietteLayer;
    private void Start()
    {
        totalLocalHauteurY = 1f;//1 car l'assiette sera le parent de tout or les enfant se réfère au scale du parent
        _ingredientLayer = LayerMask.NameToLayer("Ingredients");
        _assietteLayer = LayerMask.NameToLayer("Assiettes");

    }

    private void OnTriggerEnter(Collider other)
    {
        //Quand on détecte qu'un objet rentre dans dans la zone de collision 
        //On vérifie qu'il n'appartient pas a IngredientHolder ( donc qu'il n'ai plus attraper par le joueur )
        if (other.gameObject.transform.parent.name == _IngredientHolder.transform.name)
        {
            //On vérifie que c'est un ingrédient
            if (other.gameObject.layer == _ingredientLayer)
            {
                //On définie sa nouvelle position
                NewAssemblerMakerPosition(other.gameObject.transform.localScale.y);
                //On le met en enfant de l'assiette
                Join(other.gameObject,_Assiette);
                //On ajoute le gameObject a la list
                _ListIngredients.Add(other.gameObject);
            }
        }
            
    }

    private void Update()
    {
        //Debug.Log(_ListIngredients.Count);
    }


    private void Join(GameObject child, GameObject parent)
    {
        child.layer = _assietteLayer;//L'ingrédient devient une partie de l'assiette
        child.transform.localRotation = Quaternion.identity;
        child.transform.parent = parent.transform;
        totalLocalHauteurY += child.transform.localScale.y/2f + ancienneHauteurY;
        ancienneHauteurY = child.transform.localScale.y / 2f;
        child.GetComponent<Rigidbody>().isKinematic = true;
        child.transform.localPosition = new Vector3(0f,totalLocalHauteurY,0f);
        

    }

    private void NewAssemblerMakerPosition(float yMovement)
    {
        transform.position += new Vector3(0,yMovement/4f, 0);
    }
}
