using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform character;
    public Vector3 offset;
    public Vector2 minpos;
    public Vector2 maxpos;

    void LateUpdate()
    {
        float x = Mathf.Clamp(character.position.x, minpos.x, maxpos.x);
        float y = Mathf.Clamp(character.position.y, minpos.y, maxpos.y);
        transform.position = new Vector3(x, y, transform.position.z);// + offset;
    }
}
