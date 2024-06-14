public class Key : Item
{
    public int id = -1;

    public void OnUsed() 
    { 
        Destroy(gameObject);
    }    
}
