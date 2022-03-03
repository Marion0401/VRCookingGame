using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AssemblageBoissonFrie : MonoBehaviour
{
    [SerializeField] private GameObject _plateau;
    [SerializeField] private GameObject _IngredientHolder;
    [SerializeField] private Vector3 _friePos;
    [SerializeField] private Vector3 _sodaPos;
    private GameObject frie = null;
    private GameObject soda = null;
    private bool sodaHasBeenGrab = false;
    private bool frieHasBeenGrab = false;
    private LayerMask _ingredientLayer;
    private LayerMask _plateaulayer;
    private void Awake()
    {
        _ingredientLayer = LayerMask.NameToLayer("Ingredients");
        _plateaulayer = LayerMask.NameToLayer("Plateau");
    }

    private void Update()
    {
        if (soda != null)
        {

            // Partie de programme qui permet à l'utilisateur de pouvoir grab le soda
            Transform sodaTransform = soda.transform.parent;
            if (sodaTransform == null)
            {
                sodaHasBeenGrab = true;
            }

            if (sodaTransform != null & sodaHasBeenGrab)
            {
                //Si l'utilisateur à grab et lacher l'objet, on le remove du plateau
                RemoveSodaFromPlateau();
                sodaHasBeenGrab = false;
            }

            // Partie de programme qui permet à l'utilisateur de pouvoir grab les frites
            Transform frieTransform = frie.transform.parent;
            if (frieTransform == null)
            {
                frieHasBeenGrab = true;
            }
            if (frieTransform != null & frieHasBeenGrab)
            {
                //Si l'utilisateur à grab et lacher l'objet, on le remove du plateau
                RemoveFrieFromPlateau();
                frieHasBeenGrab = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Quand on détecte qu'un objet rentre dans dans la zone de collision 
        //On vérifie qu'il appartient a IngredientHolder ( donc qu'il n'ai plus attraper par le joueur )
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.transform.parent.name == _IngredientHolder.transform.name)
        {
            //On vérifie que c'est les ingrédients
            if (otherGameObject.layer == _ingredientLayer)
            {
                EnumIngredient typeOfIngredient = other.GetComponent<IngredientType>().typeOfIngredient;
                if (typeOfIngredient == EnumIngredient.Frites & frie == null)
                {
                    _plateau.GetComponent<IngredientOnPlateau>().frieIngredient = typeOfIngredient;
                    frie = otherGameObject;
                    JoinFrie(otherGameObject);
                }

                if (typeOfIngredient == EnumIngredient.Coca & soda == null)
                {
                    _plateau.GetComponent<IngredientOnPlateau>().sodaIngredient = typeOfIngredient;
                    soda = otherGameObject;
                    JoinSoda(otherGameObject);
                }


                _plateau.GetComponent<PlateauToOrder>().UpdateOrder();
            }
        }

    }

    private void JoinSoda(GameObject child)
    {
        //Fonction qui permet de placer le soda à la bonne position du plateau
        child.layer = _plateaulayer;//L'ingrédient devient une partie du plateau
        child.transform.localRotation = Quaternion.identity;
        child.transform.parent = transform;
        child.transform.localPosition = new Vector3(_sodaPos.x, _sodaPos.y, _sodaPos.z);
        child.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void JoinFrie(GameObject child)
    {
        //Fonction qui permet de placer les frites à la bonne position du plateau
        child.layer = _plateaulayer;//L'ingrédient devient une partie du plateau
        child.transform.localRotation = Quaternion.identity;
        child.transform.parent = transform;
        child.transform.localPosition = new Vector3(_friePos.x, _friePos.y, _friePos.z);
        child.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void RemoveSodaFromPlateau()
    {
        soda.GetComponent<Rigidbody>().isKinematic = false;
        soda.transform.parent = _IngredientHolder.transform;
        soda.layer = _ingredientLayer;
        soda = null;
    }

    private void RemoveFrieFromPlateau()
    {
        frie.GetComponent<Rigidbody>().isKinematic = false;
        frie.transform.parent = _IngredientHolder.transform;
        frie.layer = _ingredientLayer;
        frie = null;
    }

    public void ResetBoissonFrie()
    {
        Destroy(frie);
        Destroy(soda);
        frie = null;
        soda = null;
        sodaHasBeenGrab = false;

    }
}
