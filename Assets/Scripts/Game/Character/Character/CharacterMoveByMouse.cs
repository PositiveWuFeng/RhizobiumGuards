using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class CharacterMoveByMouse : MonoBehaviour
{
    public LayerMask LayerMask;
    private void Start()
    {
        LayerMask = LayerMask.NameToLayer("Back");
    }
    void OnMouseDown()
    {

    }
    private void OnMouseDrag()
    {
        if (GameManager.Instance.myGameState == GameManager.GameState.Prepare)
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(pos.x > MouseMoveLimit.Instance.left.position.x&&pos.x < MouseMoveLimit.Instance.right.position.x && pos.y < MouseMoveLimit.Instance.up.position.y && pos.y > MouseMoveLimit.Instance.down.position.y)
            {
                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            }
           
            /*            transform.position = Input.mousePosition;
                        var ra = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;

                        if (Physics.Raycast(ra, out hit, LayerMask))
                        {
                            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
                            Debug.Log("@_@ " + transform.position);
                        }*/
        }
    }
}
