using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class makeCircleRenderer : MonoBehaviour {

	public float radius = 1.0f;
 	[Range(3, 256)]
	public int numSegments = 128;
	void Awake(){
		radius = BuildingController.buildControl.DistanceMax/3;
 	}

	void Start ( ) {
 		DoRenderer();

	}

	public void DoRenderer ( ) {
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
		Color c1 = Color.blue;
  		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c1);
		lineRenderer.SetWidth(0.1f, 0.1f);
		lineRenderer.SetVertexCount(numSegments + 1);
		lineRenderer.useWorldSpace = false;

		float deltaTheta = (float) (2.0 * Mathf.PI) / numSegments;
		float theta = 0f;

		for (int i = 0 ; i < numSegments + 1 ; i++) {
			float x = radius * Mathf.Cos(theta);
			float y = radius * Mathf.Sin(theta);
			Vector3 pos = new Vector3(x, y, 0);
			lineRenderer.SetPosition(i, pos);
			theta += deltaTheta;
		}
	}

}
