using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public Sheep dolly; // assign this PREFAB in inspector
    public TextMesh fameMeter; // assign this reference in inspector
	public FloatingText floater; // assign this PREFAB reference in inspector

    // "static" means this variable doesn't live in the scene
    // it means that this variable lives inside the code itself
    // and if we combine this with "public" then ANY PIECE OF CODE ANYWHERE can access the var!
    //      e.g. if we made 20 copies of PlayerInput on 20 gameObjects
    //      then they would all still only reference the SAME "selectedSheep"
    //      because it is *static*, it lives in the class definition itself
    public static Sheep currentSheep;
    // the reason this is USEFUL: you no longer have to drag and drop anything
    // 		and you don't have to use GetComponent because this variable lives in code!
    // the reason this is TERRIBLE: anything in the code can read and write to this var
    // 		which means a lot of complexity; if something goes wrong, it could be ANYWHERE
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit rayHit = new RaycastHit();

        if ( Physics.Raycast( ray, out rayHit, 10000f ) ) {

            if ( Input.GetMouseButtonDown( 0 ) && rayHit.collider.tag == "Sheep" ) {
                // whatever code runs here is when:
                // 1) the mouse is over a GameObject with a collider and "Sheep" tag
                // 2) AND when the mouse is left-clicked
                Sheep selectedSheep = rayHit.collider.GetComponent<Sheep>();
                fameMeter.text = "sheep fame = " + selectedSheep.fame.ToString();

                // added on 11/14/2013
                currentSheep = selectedSheep; // saves what sheep we clicked on

				// added on 11/21/2013
				// spawn a new floating text object
				FloatingText newFloater = Instantiate ( floater, rayHit.point, Quaternion.identity) as FloatingText;
				newFloater.GetComponent<TextMesh>().text = "FAME: " + selectedSheep.fame.ToString();
            }

            if ( Input.GetMouseButtonDown( 1 ) ) {
                // whatever code runs here is when:
                // 1) the mouse is over anything with a collider
                // 2) AND when the mouse is right-clicked
                Sheep newSheep = Instantiate( dolly, rayHit.point, Quaternion.identity ) as Sheep;
                newSheep.fame = Random.Range( 1, 100 );
            }

        } // this closes out Raycast()


	} // this close out Update()

}
