using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEditor;

public class PointHelper : MonoBehaviour
{
	#if UNITY_EDITOR
	    [ContextMenu("Set on ground")]
	    public void SetOnGround()
	  	{
	        if (Physics.Raycast(transform.position + Vector3.up * 100, Vector3.down, out var hit, 200,
	            LayerMask.GetMask("Ground")))
	        {
	            Undo.RecordObject(transform, "point set on ground");
	            transform.position = hit.point;
	        }
	    }
	#endif
}