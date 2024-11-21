using System.Collections;
using UnityEngine;
using Photon.Pun;

public class PlayerColor : MonoBehaviourPunCallbacks
{
    private Renderer myRenderer;
    private MaterialPropertyBlock propBlock;
    void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        if (myRenderer != null)
        {
            myRenderer.material = new Material(myRenderer.material);
        }
        propBlock = new MaterialPropertyBlock();
    }
    void Start()
    {
        if (photonView.IsMine)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeColorAfterDelay());
    }
    IEnumerator ChangeColorAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Color newColor = new Color(Random.value, Random.value, Random.value);
        photonView.RPC("UpdateColor", RpcTarget.AllBuffered, newColor.r, newColor.g, newColor.b);
    }
    [PunRPC]

    void UpdateColor(float r, float g, float b)
    {
        Debug.Log("RPC received - Updating Color");
        ApplyColor(new Color(r, g, b));
    }

    private void ApplyColor(Color color)
    {
        Debug.Log("Applying Color:" + color);
        if (myRenderer != null)
        {
            myRenderer.GetPropertyBlock(propBlock);

            Debug.Log("Applying Color2:" + color);
            propBlock.SetColor("_Color", color);
            myRenderer.SetPropertyBlock(propBlock);

        }
        else
        { 
        Debug.LogError("Renderer not found on" + gameObject.name);
        }

    }
}
