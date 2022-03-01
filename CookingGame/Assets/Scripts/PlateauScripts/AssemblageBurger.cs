using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AssemblageBurger : MonoBehaviour
{
    [SerializeField] private GameObject _plateau;
    [SerializeField] private GameObject _assiette;
    [SerializeField] private GameObject _IngredientHolder;
    private List<GameObject> _listIngredientsGameObjects = new List<GameObject>();
    public List<EnumIngredient> listIngredientsType = new List<EnumIngredient>();
    [SerializeField] private float totalLocalHauteurY;
    private float ancienneHauteurY;
    private LayerMask _ingredientLayer;
    private LayerMask _assietteLayer;
    private bool hasBeenGrapped;
    private Vector3 startColliderPos;
    private void Awake()
    {
        startColliderPos = transform.position;
        hasBeenGrapped = false;
        totalLocalHauteurY = 0.04f;//1 car l'assiette sera le parent de tout or les enfant se réfère au scale du parent
        _ingredientLayer = LayerMask.NameToLayer("Ingredients");
        _assietteLayer = LayerMask.NameToLayer("Assiettes");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Quand on détecte qu'un objet rentre dans dans la zone de collision 
        //On vérifie qu'il appartient a IngredientHolder ( donc qu'il n'ai plus attraper par le joueur )
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.transform.parent != null)
        {
            if (otherGameObject.transform.parent.name == _IngredientHolder.transform.name)
            {
                //On vérifie que c'est un ingrédient
                if (otherGameObject.layer == _ingredientLayer)
                {
                    EnumIngredient typeOfIngredient = otherGameObject.GetComponent<IngredientType>().typeOfIngredient;
                    if (typeOfIngredient != EnumIngredient.Coca && typeOfIngredient != EnumIngredient.Frites)
                    {
                        //On le met en enfant de l'assiette
                        Join(otherGameObject, _assiette);
                        //On ajoute le gameObject a la list
                        _listIngredientsGameObjects.Add(otherGameObject);
                        listIngredientsType.Add(typeOfIngredient);
                        _plateau.GetComponent<IngredientOnPlateau>().burgerIngredient = listIngredientsType;

                        //On définie sa nouvelle position
                        NewAssemblerMakerPosition();

                        _plateau.GetComponent<PlateauToOrder>().UpdateOrder();
                    }
                }
            }
        }

    }

    private void Update()
    {
        int nbOfIngredientInList = _listIngredientsGameObjects.Count;
        int nbOfIngredientInChild = _assiette.GetComponentsInChildren<Transform>().Length - 2;
        //Debug.Log("nbOfIngredientInList" + nbOfIngredientInList);
        //Debug.Log("nbOfIngredientInChild" + nbOfIngredientInChild);
        //Quand un objet est attraper par l'utilisateur, il revient en haut de l'arboraissance et n'a plus de parent
        if (nbOfIngredientInList != nbOfIngredientInChild)
        {
            //L'élement est actuellement dans la main de l'utilisateur, on doit attendre
            //que l'utilisateur le dépose pour pouvoir le modifier
            hasBeenGrapped = true;
        }

        //Quand l'utilisateur dépose l'objet
        if ((nbOfIngredientInList == nbOfIngredientInChild) & hasBeenGrapped)
        {
            LastIngredientGrapped(_listIngredientsGameObjects[nbOfIngredientInList - 1]);
            hasBeenGrapped = false;
        }
    }


    private void Join(GameObject child, GameObject parent)
    {
        int nbOfIngredientInList = _listIngredientsGameObjects.Count;
        child.layer = _assietteLayer;//L'ingrédient devient une partie de l'assiette
        if (child.GetComponent<IngredientType>().typeOfIngredient == EnumIngredient.Salade)
        {
            child.transform.localRotation = Quaternion.Euler(90f, 0, 0);
            child.transform.parent = parent.transform;
            totalLocalHauteurY += 0.05f / 2f + ancienneHauteurY;
            ancienneHauteurY = 0.05f;
            child.GetComponent<Rigidbody>().isKinematic = true;
            child.transform.localPosition = new Vector3(0f, totalLocalHauteurY, 0f);
        }
        else
        {
            child.transform.localRotation = Quaternion.identity;
            child.transform.parent = parent.transform;
            totalLocalHauteurY += child.transform.localScale.y / 2f + ancienneHauteurY;
            ancienneHauteurY = child.transform.localScale.y / 2f;
            child.GetComponent<Rigidbody>().isKinematic = true;
            child.transform.localPosition = new Vector3(0f, totalLocalHauteurY, 0f);
        }

        if (nbOfIngredientInList != 0)
        {
            _listIngredientsGameObjects[nbOfIngredientInList - 1].GetComponent<XRGrabInteractable>().enabled = false;
        }

    }

    private void NewAssemblerMakerPosition()
    {
        transform.position = _listIngredientsGameObjects[_listIngredientsGameObjects.Count - 1].transform.position;
    }

    public void LastIngredientGrapped(GameObject ingredient)
    {
        Transform ingredientTransform = ingredient.transform;
        float ingredientTransformLocalScaleY = ingredientTransform.localScale.y;

        //On réinitialise l'ingrédient qui a été enlevé de l'hamburger
        ingredientTransform.parent = _IngredientHolder.transform;
        ingredient.layer = _ingredientLayer;
        ingredient.GetComponent<Rigidbody>().isKinematic = false;

        //L'ingrédient ne fait plus partie de l'hamburger, donc, il ne fait plus partie des listes
        _listIngredientsGameObjects.Remove(ingredient);
        listIngredientsType.RemoveAt(listIngredientsType.Count - 1);
        _plateau.GetComponent<IngredientOnPlateau>().burgerIngredient = listIngredientsType;

        //On reset la position de la hitbox
        totalLocalHauteurY -= ingredientTransformLocalScaleY / 2f + ancienneHauteurY;
        ancienneHauteurY = ingredientTransformLocalScaleY / 2f;
        NewAssemblerMakerPosition();

        //On fait en sorte que le nouveau dernier ingredient est grappable par l'utilisateur
        if (_listIngredientsGameObjects.Count != 0)
        {
            _listIngredientsGameObjects[_listIngredientsGameObjects.Count - 1].GetComponent<XRGrabInteractable>().enabled = true;
        }



    }

    public void ResetBurger()
    {
        //Après validation d'une recette, on reset le plateau en détruisant les gameObject qu'il contient et
        //reinitialisant ces variables
        for (int i = 0; i < _listIngredientsGameObjects.Count; i++)
        {
            Destroy(_listIngredientsGameObjects[i]);
        }

        transform.position = startColliderPos;
        _listIngredientsGameObjects = new List<GameObject>();
        listIngredientsType = new List<EnumIngredient>();
        totalLocalHauteurY = 0.04f;
        ancienneHauteurY = 0f;
        hasBeenGrapped = false;
    }
}