using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Teo.Scripts
{
    public class AssemblageIngrédients : Assiette
    {
        [SerializeField] private GameObject _IngredientAssembleHolder;
        [SerializeField] private GameObject _IngredientNonAssembleHolder;
        [SerializeField] private NameOfObject Type;
        private float totalLocalHauteurY;
        private float ancienneHauteurY;
        private LayerMask _ingredientLayer;
        private LayerMask _assietteLayer;
        private void Awake()
        {
            totalLocalHauteurY = 0.1f;
            _ingredientLayer = LayerMask.NameToLayer("Ingredients");
            _assietteLayer = LayerMask.NameToLayer("Assiettes");
        }

        private void OnTriggerEnter(Collider other)
        {
            //Quand on détecte qu'un objet rentre dans dans la zone de collision 
            //On vérifie qu'il n'appartient pas a IngredientHolder ( donc qu'il n'ai plus attraper par le joueur )
            if (other.gameObject.transform.parent.name == _IngredientNonAssembleHolder.transform.name)
            {
                //On vérifie que c'est un ingrédient
                if (other.gameObject.layer == _ingredientLayer)
                {
                    //On vérifie que l'objet ne soit pas dans la main du joueur
                    if (other.gameObject.GetComponent<Ingredient>().isHolded == false)
                    {
                        //On définie sa nouvelle position
                        NewAssemblerMakerPosition(other.gameObject.transform.localScale.y);
                        //On le met en enfant de l'assiette
                        Join(other.gameObject,_IngredientAssembleHolder);
                        //On ajoute le gameObject a la bonne list
                        if (Type == NameOfObject.Assiette1)
                            ListIngredientsAssiette1.Add(other.gameObject);
                        if (Type == NameOfObject.Assiette2)
                            ListIngredientsAssiette2.Add(other.gameObject);
                        if (Type == NameOfObject.Assiette3)
                            ListIngredientsAssiette3.Add(other.gameObject);   
                    }
                }
            }
            
        }

        private void Update()
        {
            //Debug.Log(ListIngredientsAssiette1.Count);
            //Debug.Log(_IngredientAssembleHolder);
        }


        private void Join(GameObject child, GameObject parent)
        {
            child.layer = _assietteLayer;//L'ingrédient devient une partie de l'assiette
            child.transform.localRotation = Quaternion.identity;
            child.transform.parent = parent.transform;
        
            var localScale = child.transform.localScale;
            totalLocalHauteurY += localScale.y/2f + ancienneHauteurY;
            ancienneHauteurY = localScale.y / 2f;
        
            child.GetComponent<Rigidbody>().isKinematic = true;
            child.transform.localPosition = new Vector3(0f,totalLocalHauteurY,0f);
            child.GetComponent<XRGrabInteractable>().enabled = false;
            child.GetComponent<Ingredient>().Assembled();
        

        }

        private void NewAssemblerMakerPosition(float yMovement)
        {
            transform.position += new Vector3(0,yMovement/1f, 0);
        }
    }
}
