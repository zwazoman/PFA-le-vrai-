using UnityEngine;

public class Grow : MonoBehaviour
{
    /// <summary>
    /// Fais poussez les plantes
    /// </summary>
    public void IsGrowing() //Pousse quand on passe a jour suivant (surement a modifier plus tard)
    {
        transform.position += new Vector3(0,0.5f,0); 
        Debug.Log("�a pousse");
        if (TimeManager.Instance.Day == 4)
        {
            Destroy(gameObject);
        }
    }
}
