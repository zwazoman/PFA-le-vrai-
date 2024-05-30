using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class Bulle : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] ImagesBulles images;
    [SerializeField] Image renderer;
    Transform target;
    Vector3 offset;

    public void setUp(int id, GameObject attachedGameObject, Vector3 _offset)
    {
        /*MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        materialPropertyBlock.SetTexture("_Texture2D", images.textures[id]);*/
        renderer.sprite = images.textures[id];

        target = attachedGameObject.transform;
        this.offset = _offset;

        animator.SetTrigger(0);
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.position = target.position+CameraBehaviour.Instance.transform.up * offset.y;
    }

    private IEnumerator Start()
    {
        yield return null;
        if(target == null)
        {
            Debug.LogError("T'as pas set up la bulle gros fils de pute va");
            Destroy(gameObject);
        }
    }
}
