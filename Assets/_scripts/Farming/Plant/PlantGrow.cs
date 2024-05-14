using UnityEngine;
    /// <summary>
    /// Fais poussez les plantes
    /// </summary>
public class PlantGrow : MonoBehaviour
{
    private void Start()
    {
        TimeManager.Instance.OnDay += IsGrowing;
    }
    public void IsGrowing() //Pousse quand on passe a jour suivant (surement a modifier plus tard)
    {
        transform.position += new Vector3(0,0.5f,0); 
        Debug.Log("ça pousse");
        if (TimeManager.Instance.Day == 4)
        {
            Destroy(gameObject);
        }
    }
}
